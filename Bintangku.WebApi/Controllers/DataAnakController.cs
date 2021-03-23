using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Services.Extensions;
using Bintangku.Services.Interfaces;
using Bintangku.WebApi.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class DataAnakController : BaseApiController
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public DataAnakController(
            ApplicationDataContext context, 
            IMapper mapper,
            IPhotoService photoService)
        {
            _mapper = mapper;
            _context = context;
            _photoService = photoService;
        }

        /// <summary>
        /// HTTP Get to get all data anak from data base
        /// </summary>
        /// <returns>List of data anak</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataAnak>>> GetDataAnaks()
        {
            var dataAnak = await _context.DataAnaks
                .Select(anak => new
                {   
                    Id = anak.Id,
                    NamaLengkap = anak.NamaLengkap,
                    Nik = anak.NIK,
                    JenisKelaminAnak = anak.JenisKelamin,
                    TanggalLahirAnak = anak.TanggalLahirAnak,
                    Alamat = anak.Alamat,
                    Kontak = anak.Kontak,
                    ImagePath = anak.ImagePath,
                    JumlahSaudara = anak.JumlahSaudara,
                    RiwayatKelahiran = anak.RiwayatKelahiran,
                    RiwayatOrangTua = anak.RiwayatOrangTua,
                    NamaNakes = anak.NakesUser.FullName,
                    NakesPhoto = anak.NakesUser.Photos
                        .Select(p => new { Url = p.Url })
                })
                .ToListAsync();

            return Ok(dataAnak);
        }

        /// <summary>
        /// HTTP Get to get specific data anak based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific data anak</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DataAnak>> GetDataAnak(int id)
        {
            var dataAnak = await _context.DataAnaks
                .Where(x => x.Id == id)
                .Select(anak => new 
                {
                    Id = anak.Id,
                    NamaLengkap = anak.NamaLengkap,
                    Nik = anak.NIK,
                    JenisKelaminAnak = anak.JenisKelamin,
                    TanggalLahirAnak = anak.TanggalLahirAnak,
                    Alamat = anak.Alamat,
                    Kontak = anak.Kontak,
                    ImagePath = anak.ImagePath,
                    JumlahSaudara = anak.JumlahSaudara,
                    RiwayatKelahiran = anak.RiwayatKelahiran,
                    RiwayatOrangTua = anak.RiwayatOrangTua,
                    NamaNakes = anak.NakesUser.FullName,
                    NakesPhoto = anak.NakesUser.Photos
                        .Select(p => new { Url = p.Url })
                })
                .SingleAsync();

                if (dataAnak.Id != id) return BadRequest("Data Anak Tidak Ditemukan!");
            
            return Ok(dataAnak);
        }

        /// <summary>
        /// HTTP Post to create new data anak and then save it onto data base 
        /// </summary>
        /// <param name="dataAnakDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateDataAnak([FromBody] PostDataAnak postDataAnak)
        {
            var currentNakesUsername = User.GetUserName();
            var currentNakes = _context.Users.SingleOrDefaultAsync(
                x => x.UserName == currentNakesUsername);

            var dataToPost = new DataAnak
            {
                NamaLengkap = postDataAnak.NamaLengkap,
                NIK = postDataAnak.NIK,
                JenisKelamin = postDataAnak.JenisKelaminAnak,
                TanggalLahirAnak = postDataAnak.TanggalLahirAnak,
                Alamat = postDataAnak.Alamat,
                Kontak = postDataAnak.Kontak,
                ImagePath = postDataAnak.ImagePath,
                JumlahSaudara = postDataAnak.JumlahSaudara,
                // Riwayat Kelahiran
                RiwayatKelahiran = new RiwayatKelahiran
                {
                    BeratBadan = postDataAnak.BeratBadan,
                    PanjangLahir = postDataAnak.PanjangLahir,
                    ApgarScore = postDataAnak.ApgarScore,
                    KelahiranDibantuOleh  = postDataAnak.KelahiranDibantuOleh,
                    LainLain = postDataAnak.LainLain,
                },
                // Riwayat Orang Tua
                RiwayatOrangTua = new RiwayatOrangTua
                {
                    NamaAyah = postDataAnak.NamaAyah,
                    TanggalLahirAyah = postDataAnak.TanggalLahirAyah,
                    PekerjaanAyah = postDataAnak.PekerjaanAyah,
                    NamaIbu = postDataAnak.NamaIbu,
                    TanggalLahirIbu = postDataAnak.TanggalLahirIbu,
                    PekerjaanIbu = postDataAnak.PekerjaanIbu,
                    PenghasilanOrangTua = postDataAnak.PenghasilanOrangTua,
                    AnggotaRumahTangga = postDataAnak.AnggotaRumahTangga,
                    TandaTanganPath = postDataAnak.TandaTanganPath
                },
                // Nakes
                NakesUser = currentNakes.Result,
                UserId = currentNakes.Id
            };  

            _context.Add(dataToPost);
            
            if (await _context.SaveChangesAsync() > 0)
                return Ok();
                
            return BadRequest("Failed to save data anak");
        }
        
        /// <summary>
        /// Update Specific Data Anak
        /// </summary>
        /// <param name="id">Uniqe anak id</param>
        /// <param name="updateDataAnak"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDataAnak(
            int id, [FromBody]UpdateDataAnak updateDataAnak)
        {
            var anak = await _context.DataAnaks
                .SingleOrDefaultAsync(anak => anak.Id == id);
            
            if (anak == null) return BadRequest("Data Anak Tidak Ditemukan");
            
            // Update Prfile Anak
            anak.NamaLengkap = updateDataAnak.NamaLengkap;
            anak.NIK = updateDataAnak.NIK;
            anak.JenisKelamin = updateDataAnak.JenisKelaminAnak;
            anak.TanggalLahirAnak = updateDataAnak.TanggalLahirAnak;
            anak.Alamat = updateDataAnak.Alamat;
            anak.Kontak = updateDataAnak.Kontak;
            anak.JumlahSaudara = updateDataAnak.JumlahSaudara;

            // Update Riwayat Kelahiran Data
            // anak.RiwayatKelahiran.BeratBadan = updateDataAnak.BeratBadan;
            // anak.RiwayatKelahiran.PanjangLahir = updateDataAnak.PanjangLahir;
            // anak.RiwayatKelahiran.ApgarScore = updateDataAnak.ApgarScore;
            // anak.RiwayatKelahiran.KelahiranDibantuOleh = updateDataAnak.KelahiranDibantuOleh;
            // anak.RiwayatKelahiran.LainLain = updateDataAnak.LainLain;

            // Update Riwayat Orang Tua Data
            // anak.RiwayatOrangTua.NamaAyah = updateDataAnak.NamaAyah;
            // anak.RiwayatOrangTua.TanggalLahirAyah = updateDataAnak.TanggalLahirAyah;
            // anak.RiwayatOrangTua.PekerjaanAyah = updateDataAnak.PekerjaanAyah;
            // anak.RiwayatOrangTua.NamaIbu = updateDataAnak.NamaIbu;
            // anak.RiwayatOrangTua.TanggalLahirIbu = updateDataAnak.TanggalLahirIbu;
            // anak.RiwayatOrangTua.PekerjaanIbu = updateDataAnak.PekerjaanIbu;
            // anak.RiwayatOrangTua.PenghasilanOrangTua = updateDataAnak.PenghasilanOrangTua;
            // anak.RiwayatOrangTua.AnggotaRumahTangga = updateDataAnak.AnggotaRumahTangga;
            // anak.RiwayatOrangTua.TandaTanganOrangTua = updateDataAnak.TandaTanganOrangTua;

            _context.Entry(anak).State = EntityState.Modified; 

            await _context.SaveChangesAsync();
            

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateDataAnak(int id)
        {
            var anak = await _context.DataAnaks
                .Where(x => x.Id == id)
                .Include(r => r.RiwayatKelahiran)
                .Include(o => o.RiwayatOrangTua)
                .Include(n => n.NakesUser)
                .SingleAsync();
            
            if (anak == null) return BadRequest("Data Anak Tidak Ditemukan!");
            
            _context.Remove(anak);

            await _context.SaveChangesAsync();
            
            return Ok();
        }

        /// <summary>
        /// Add Photo anak to Cloudinary
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("add-photo")]
        public async Task<ActionResult> AddPhotoAnak(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);
            
            if (result.Error != null)
                return BadRequest();

            return Ok(new { Url = result.Url});
        }
        
        [HttpPost("add-ttd")]
        public async Task<ActionResult> AddTtd(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest();
            
            return Ok(new { Url = result.Url});
        }
    }
}