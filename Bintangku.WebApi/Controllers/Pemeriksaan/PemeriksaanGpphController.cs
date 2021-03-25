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
    public class PemeriksaanGpphController : BaseApiController
    {
        private ApplicationDataContext _context;
        public PemeriksaanGpphController(ApplicationDataContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// GET data pemeriksaan GPPH
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Data pemeriksaan GPPH</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<PemeriksaanGpph>> GetPemeriksaanGpph(int dataAnakId)
        {
            try
            {
                var pemeriksaanGpph = await _context.PemeriksaanGpphs
                    .Where(x => x.KesehatanAnak.DataAnakId == dataAnakId)
                    .Select(x => new 
                    {
                        Point = x.Point,
                        Interpretasi = x.Interpretasi,
                        Intervensi = x.Intervensi
                    })
                    .ToListAsync();
                
                if (pemeriksaanGpph == null)
                    return BadRequest();
                return Ok(pemeriksaanGpph); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// POST data pemeriksaan Gpph to specific data kesehatan anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanGpphDto">Data transfer object for pemeriksaan GPPH</param>
        /// <returns></returns>
        [HttpPost("{dataAnakId}")] 
        public async Task<IActionResult> CreatePemeriksaanGpph(int dataAnakId, [FromBody]PemeriksaanGpphDto pemeriksaanGpphDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(id => id.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanGpphs)
                    .SingleOrDefaultAsync();
            
                var interpretasi = "";
                var intervensi = "";
                
                // Determine Interpretasi and Intervensi Based on input Point
                if (pemeriksaanGpphDto.Point >= 13)
                {
                    interpretasi = "GPPH";
                    intervensi = "Rujuk Ke Rumah Sakit";
                }
                else
                {
                    interpretasi = "None";
                    intervensi = "Tidak Perlu Rujuk Ke Rumah Sakit";
                }
                
                var pemeriksanGpph = new PemeriksaanGpph 
                { 
                    Point = pemeriksaanGpphDto.Point,
                    Interpretasi = interpretasi,
                    Intervensi = intervensi
                };

                // Add Pemeriksaan GPPH to Database
                dataAnak.KesehatanAnak.PemeriksaanGpphs.Add(pemeriksanGpph);
                
                if (await _context.SaveChangesAsync() > 0)
                    return Ok();
                return BadRequest("Failed to add Pemeriksaan GPPH");            
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}