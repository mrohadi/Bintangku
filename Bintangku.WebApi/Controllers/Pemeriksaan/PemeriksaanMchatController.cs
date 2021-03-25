using System;
using System.Linq;
using System.Threading.Tasks;
using Bintangku.Data;
using Bintangku.Data.Entities;
using Bintangku.WebApi.Controllers;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.Controllers.Pemeriksaan
{
    [Authorize]
    public class PemeriksaanMchatController : BaseApiController
    {
        private ApplicationDataContext _context;
        public PemeriksaanMchatController(ApplicationDataContext context)
        {
            _context = context;    
        }
        
        /// <summary>
        /// GET data pemeriksaan M-CHAT based on specific dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <returns>Data pemeriksaan M-CHAT</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<PemeriksaanMchat>> GetPemeriksaanMchat(int dataAnakId)
        {
            try
            {
                var pemeriksaanMchat = await _context.PemeriksaanMchats
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)   
                    .Select(kesehatan => new
                    {
                        JumlahYa = kesehatan.JumlahYa,
                        JumlahTidak = kesehatan.JumlahTidak,
                        Interpretasi = kesehatan.Interpretasi,
                        Intervensi = kesehatan.Intervensi
                    })
                    .ToListAsync();
                    
                if(pemeriksaanMchat == null)
                    return BadRequest();
                return Ok(pemeriksaanMchat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            } 
        }

        /// <summary>
        /// POST data pemeriksaan M-CHAT to data base based on specific dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <param name="pemeriksaanMchatDto">Data transfer object for pemeriksaan M-CHAT</param>
        /// <returns></returns>
        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostPemeriksaanMchat(
            int dataAnakId, [FromBody]PemeriksaanMchatDto pemeriksaanMchatDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanMchats)
                    .SingleOrDefaultAsync();

                if(dataAnak == null)
                    return BadRequest("Data Anak Tidak Ditemukan");
                
                string interpretasi = "";
                string intervensi = "";

                // Determine interpretasi and intervensi based on input 
                if(pemeriksaanMchatDto.JumlahTidak >= 5)
                {
                    interpretasi = "Memiliki Resiko Autisme";
                    intervensi = "Rujuk Ke Rumah Sakit";
                }

                var dataPemeriksaanMchat = new PemeriksaanMchat
                {
                    JumlahYa = pemeriksaanMchatDto.JumlahYa,
                    JumlahTidak = pemeriksaanMchatDto.JumlahTidak,
                    Interpretasi = interpretasi,
                    Intervensi = intervensi
                };
                
                // Add data pemeriksaan M-CHAT to database
                dataAnak.KesehatanAnak.PemeriksaanMchats.Add(dataPemeriksaanMchat);

                if(await _context.SaveChangesAsync() > 0)
                    return Ok();
                return BadRequest("Failed to save data pemeriksaan M-CHAT to data base");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}