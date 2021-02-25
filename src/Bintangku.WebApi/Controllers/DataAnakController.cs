using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Services.Extensions;
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
        /// HTTP Post to create new data anak and then save it onto data base 
        /// </summary>
        /// <param name="dataAnakDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateDataAnak([FromBody] PostDataAnak postDataAnak)
        {
            var currentNakesUsername = User.GetUserName();
            var currentNakes = _context.NakesUsers.SingleOrDefaultAsync(
                x => x.UserName == currentNakesUsername);

            var dataToPost = new DataAnak
            {
                NamaLengkap = postDataAnak.NamaLengkap,
                NIK = postDataAnak.NIK,
                JenisKelamin = postDataAnak.JenisKelaminAnak,
                TanggalLahirAnak = postDataAnak.TanggalLahirAnak,
                PhotoAnakUrl = postDataAnak.PhotoAnakUrl,
                Alamat = postDataAnak.Alamat,
                Kontak = postDataAnak.Kontak,
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
                    TandaTanganOrangTua = postDataAnak.TandaTanganOrangTua
                },
                // Nakes
                NakesUser = currentNakes.Result,
                NakesUserId = currentNakes.Id
            };  

             _context.Add(dataToPost);
            await _context.SaveChangesAsync();

            return Ok();
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
                    JumlahSaudara = anak.JumlahSaudara,
                    PhotoAnakUrl = anak.PhotoAnakUrl,
                    // Riwayat Kelahiran
                    BeratBadan = anak.RiwayatKelahiran.BeratBadan,
                    PanjangLahir = anak.RiwayatKelahiran.PanjangLahir,
                    ApgarScore = anak.RiwayatKelahiran.ApgarScore,
                    KelahiranDibantuOleh = anak.RiwayatKelahiran.KelahiranDibantuOleh,
                    LainLain = anak.RiwayatKelahiran.LainLain,
                    // Riwayat Orang Tua
                    NamaAyah = anak.RiwayatOrangTua.NamaAyah,
                    TanggalLahirAyah = anak.RiwayatOrangTua.TanggalLahirAyah,
                    PekerjaanAyah = anak.RiwayatOrangTua.PekerjaanAyah,
                    NamaIbu = anak.RiwayatOrangTua.NamaIbu,
                    TanggalLahirIbu = anak.RiwayatOrangTua.TanggalLahirIbu,
                    PekerjaanIbu = anak.RiwayatOrangTua.PekerjaanIbu,
                    PenghasilanOrangTua = anak.RiwayatOrangTua.PenghasilanOrangTua,
                    AnggotaRumahTangga = anak.RiwayatOrangTua.AnggotaRumahTangga,
                    TandaTanganOrangTua = anak.RiwayatOrangTua.TandaTanganOrangTua,
                    // Nakes
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
                    namaLengkap = anak.NamaLengkap,
                    Nik = anak.NIK,
                    JenisKelaminAnak = anak.JenisKelamin,
                    TanggalLahirAnak = anak.TanggalLahirAnak,
                    Alamat = anak.Alamat,
                    Kontak = anak.Kontak,
                    JumlahSaudara = anak.JumlahSaudara,
                    PhotoAnakUrl = anak.PhotoAnakUrl,
                    // Riwayat Kelahiran
                    BeratBadan = anak.RiwayatKelahiran.BeratBadan,
                    PanjangLahir = anak.RiwayatKelahiran.PanjangLahir,
                    ApgarScore = anak.RiwayatKelahiran.ApgarScore,
                    KelahiranDibantuOleh = anak.RiwayatKelahiran.KelahiranDibantuOleh,
                    LainLain = anak.RiwayatKelahiran.LainLain,
                    // Riwayat Orang Tua
                    NamaAyah = anak.RiwayatOrangTua.NamaAyah,
                    TanggalLahirAyah = anak.RiwayatOrangTua.TanggalLahirAyah,
                    PekerjaanAyah = anak.RiwayatOrangTua.PekerjaanAyah,
                    NamaIbu = anak.RiwayatOrangTua.NamaIbu,
                    TanggalLahirIbu = anak.RiwayatOrangTua.TanggalLahirIbu,
                    PekerjaanIbu = anak.RiwayatOrangTua.PekerjaanIbu,
                    PenghasilanOrangTua = anak.RiwayatOrangTua.PenghasilanOrangTua,
                    AnggotaRumahTangga = anak.RiwayatOrangTua.AnggotaRumahTangga,
                    TandaTanganOrangTua = anak.RiwayatOrangTua.TandaTanganOrangTua,
                    // Nakes
                    NamaNakes = anak.NakesUser.FullName,
                    NakesPhoto = anak.NakesUser.Photos
                        .Select(p => new { Url = p.Url })
                })
                .SingleAsync();

                if (dataAnak.Id != id) return BadRequest("Data Anak Tidak Ditemukan!");
            
            return Ok(dataAnak);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateDataAnak([FromQuery]int id)
        {
            var anak = await _context.DataAnaks
                .FirstOrDefaultAsync(anak => anak.Id == id);
            
            if (anak == null) return BadRequest("Data Anak Tidak Ditemukan");

            return Ok();
        }
    }
}