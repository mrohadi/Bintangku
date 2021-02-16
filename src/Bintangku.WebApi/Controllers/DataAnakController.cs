using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class DataAnakController : BaseApiController
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        public DataAnakController(ApplicationDataContext context, IMapper mapper)
        {
               _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateDataAnak(DataAnak dataAnak)
        {
            var currentNakesUsername = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentNakes = _context.NakesUsers.SingleOrDefaultAsync(
                x => x.UserName == currentNakesUsername);

            var newDataAnak = new DataAnak
            {
                NakesUserId = currentNakes.Id,
                NakesUser = currentNakes.Result,
                NamaLengkap = dataAnak.NamaLengkap,
                NIK = dataAnak.NIK,
                JenisKelamin = dataAnak.JenisKelamin,
                TanggalLahir = dataAnak.TanggalLahir,
                NamaAyah = dataAnak.NamaAyah,
                NamaIbu = dataAnak.NamaIbu,
                Alamat = dataAnak.Alamat,
                Kontak = dataAnak.Kontak,
            };
            _context.Add(newDataAnak);
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Get all data anak
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataAnak>>> GetDataAnaks()
        {
            var dataAnak = await _context.DataAnaks
                .Select(x => new
                {   
                    NamaAnak = x.NamaLengkap,
                    Nik = x.NIK,
                    JenisKelamin = x.JenisKelamin,
                    TanggalLahir = x.TanggalLahir,
                    NamaAyah = x.NamaAyah,
                    NamaIbu = x.NamaIbu,
                    Alamat = x.Alamat,
                    Kontak = x.Kontak,
                    NamaNakes = x.NakesUser.FullName,
                    NakesPhotoUrl = x.NakesUser.Photos
                        .Select(u =>u.Url)
                })
                .ToListAsync();

            return Ok(dataAnak);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DataAnak>> GetDataAnak(int id)
        {
            return await _context.DataAnaks.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}