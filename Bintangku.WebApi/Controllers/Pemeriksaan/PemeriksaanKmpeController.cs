using System;
using System.Linq;
using System.Threading.Tasks;
using Bintangku.Data;
using Bintangku.Data.DTO.Pemeriksaan;
using Bintangku.Data.Entities;
using Bintangku.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.Controllers.Pemeriksaan
{
    [Authorize]
    public class PemeriksaanKmpeController : BaseApiController
    {
        private ApplicationDataContext _context;
        public PemeriksaanKmpeController(ApplicationDataContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// GET specific data pemeriksaaan KMPE based on dataAnakId 
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <returns>Data pemriksaan KMPE</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<PemeriksaanKmpe>> GetPemeriksaanKmpe(int dataAnakId)
        {
            try
            {
                var dataPemeriksaanKmpe = await _context.PemeriksaanKmpes
                    .Where(kesehatan => kesehatan.KesehatanAnak.DataAnakId == dataAnakId)
                    .Select(pemeriksaan => new 
                    {
                        JumlahYa = pemeriksaan.JumlahYa,
                        Interpretasi = pemeriksaan.Interpretasi,
                        Intervensi = pemeriksaan.Intervensi 
                    })
                    .ToListAsync();
                
                if(dataPemeriksaanKmpe == null) 
                    return BadRequest();
                return Ok(dataPemeriksaanKmpe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// POST data kesehatan KMPE to data base based on dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <param name="pemeriksaanKmpeDto">Data transfer object for pemeriksaan KMPE</param>
        /// <returns>No return</returns>
        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostPemeriksaanKmpe(
            int dataAnakId, [FromBody]PemeriksaanKmpeDto pemeriksaanKmpeDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanKmpes)
                    .SingleOrDefaultAsync();
                
                string interpretasi = "";
                string intervensi = "";

                // Determine interpretasi and intervenis based on input
                if(pemeriksaanKmpeDto.JumlahYa == 1) 
                {
                    interpretasi = "Kemungkinan Mengalami Masalah Perilaku Emosional";
                    intervensi = "Lakukan Konseling";
                }
                else if(pemeriksaanKmpeDto.JumlahYa >= 2)
                {
                    interpretasi = "Mengalami Masalah Perilaku Emosional";
                    intervensi = "Rujuk Ke Rumah Sakit";
                }
                
                var dataPemeriksaanKmpe = new PemeriksaanKmpe
                {
                    JumlahYa = pemeriksaanKmpeDto.JumlahYa,
                    Interpretasi = interpretasi,
                    Intervensi = intervensi 
                };
                
                // Add data pemeriksaan KMPE to data base
                dataAnak.KesehatanAnak.PemeriksaanKmpes.Add(dataPemeriksaanKmpe);

                if(await _context.SaveChangesAsync() > 0) 
                    return Ok();
                return BadRequest("Failed to add save pemeriksaan KMPE to data base");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}