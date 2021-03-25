using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Services.Extensions;
using Bintangku.Services.Interfaces;
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
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Select(anak => new
                    {   
                        DataAnakId = anak.DataAnakId,
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
                        KesehatanAnak = anak.KesehatanAnak,
                        NamaNakes = anak.NakesUser.FullName,
                        NakesPhoto = anak.NakesUser.Photos
                            .Select(p => new { Url = p.Url })
                    })
                    .ToListAsync();     
                
                if(dataAnak != null)
                    return Ok(dataAnak);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Data Anak Tidak Ditemukan: ${ex}");
            }
        }

        /// <summary>
        /// HTTP Get to get specific data anak based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific data anak based on DataAnakId</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DataAnak>> GetDataAnak(int id)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(x => x.DataAnakId == id)
                    .Select(anak => new 
                    {
                        DataAnakId = anak.DataAnakId,
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
                        KesehatanAnak = anak.KesehatanAnak,
                        NamaNakes = anak.NakesUser.FullName,
                        NakesPhoto = anak.NakesUser.Photos
                            .Select(p => new { Url = p.Url })
                    })
                    .SingleAsync();
                if (dataAnak != null)
                    return Ok(dataAnak);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Data Anak Tidak Ditemukan: {ex}");
            }
        }

        /// <summary>
        /// HTTP Post to create new data anak and then save it onto data base 
        /// </summary>
        /// <param name="dataAnakDto">Data anak transfer object to post into data base</param>
        /// <returns>No Return</returns>
        [HttpPost]
        public async Task<IActionResult> CreateDataAnak(
            [FromBody] PostDataAnakDto postDataAnakDto)
        {
            try
            {
                var currentNakesUsername = User.GetUserName();
                var currentNakes = _context.Users.SingleOrDefaultAsync(
                    x => x.UserName == currentNakesUsername);

                var dataToPost = new DataAnak
                {
                    NamaLengkap = postDataAnakDto.NamaLengkap,
                    NIK = postDataAnakDto.NIK,
                    JenisKelamin = postDataAnakDto.JenisKelaminAnak,
                    TanggalLahirAnak = postDataAnakDto.TanggalLahirAnak,
                    Alamat = postDataAnakDto.Alamat,
                    Kontak = postDataAnakDto.Kontak,
                    ImagePath = postDataAnakDto.ImagePath,
                    JumlahSaudara = postDataAnakDto.JumlahSaudara,
                    // Riwayat Kelahiran
                    RiwayatKelahiran = new RiwayatKelahiran
                    {
                        BeratBadan = postDataAnakDto.BeratBadan,
                        PanjangLahir = postDataAnakDto.PanjangLahir,
                        ApgarScore = postDataAnakDto.ApgarScore,
                        KelahiranDibantuOleh  = postDataAnakDto.KelahiranDibantuOleh,
                        LainLain = postDataAnakDto.LainLain,
                    },
                    // Riwayat Orang Tua
                    RiwayatOrangTua = new RiwayatOrangTua
                    {
                        NamaAyah = postDataAnakDto.NamaAyah,
                        TanggalLahirAyah = postDataAnakDto.TanggalLahirAyah,
                        PekerjaanAyah = postDataAnakDto.PekerjaanAyah,
                        NamaIbu = postDataAnakDto.NamaIbu,
                        TanggalLahirIbu = postDataAnakDto.TanggalLahirIbu,
                        PekerjaanIbu = postDataAnakDto.PekerjaanIbu,
                        PenghasilanOrangTua = postDataAnakDto.PenghasilanOrangTua,
                        AnggotaRumahTangga = postDataAnakDto.AnggotaRumahTangga,
                        TandaTanganPath = postDataAnakDto.TandaTanganPath
                    },
                    KesehatanAnak = new KesehatanAnak
                    {
                        PemeriksaanGpphs = new List<PemeriksaanGpph> { },
                        PemeriksaanMchats = new List<PemeriksaanMchat> { },
                        PemeriksaanKmpes = new List<PemeriksaanKmpe> { }
                    },
                    // Nakes
                    NakesUser = currentNakes.Result,
                };

                _context.Add(dataToPost);

                if(await _context.SaveChangesAsync() > 0) 
                    return Ok();
                return BadRequest("Failed to Save Data Anak!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
        
        /// <summary>
        /// Update specific data anak based on DataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniqe dataAnakId</param>
        /// <param name="updateDataAnakDto">Update datan anak transfer object to update in data base</param>
        /// <returns>No Return</returns>
        [HttpPut("{dataAnakId}")]
        public async Task<IActionResult> UpdateDataAnak(
            int dataAnakId, [FromBody]UpdateDataAnakDto updateDataAnakDto)
        {
            try
            {
                var anak = await _context.DataAnaks
                .SingleOrDefaultAsync(anak => anak.DataAnakId == dataAnakId);
            
                if (anak == null) 
                    return BadRequest("Data Anak Tidak Ditemukan");
                
                // Update Prfile Anak
                anak.NamaLengkap = updateDataAnakDto.NamaLengkap;
                anak.NIK = updateDataAnakDto.NIK;
                anak.JenisKelamin = updateDataAnakDto.JenisKelaminAnak;
                anak.TanggalLahirAnak = updateDataAnakDto.TanggalLahirAnak;
                anak.Alamat = updateDataAnakDto.Alamat;
                anak.Kontak = updateDataAnakDto.Kontak;
                anak.ImagePath = updateDataAnakDto.ImagePath; 
                anak.JumlahSaudara = updateDataAnakDto.JumlahSaudara;

                // Update Riwayat Kelahiran Data
                anak.RiwayatKelahiran.BeratBadan = updateDataAnakDto.BeratBadan;
                anak.RiwayatKelahiran.PanjangLahir = updateDataAnakDto.PanjangLahir;
                anak.RiwayatKelahiran.ApgarScore = updateDataAnakDto.ApgarScore;
                anak.RiwayatKelahiran.KelahiranDibantuOleh = updateDataAnakDto.KelahiranDibantuOleh;
                anak.RiwayatKelahiran.LainLain = updateDataAnakDto.LainLain;

                // Update Riwayat Orang Tua Data
                anak.RiwayatOrangTua.NamaAyah = updateDataAnakDto.NamaAyah;
                anak.RiwayatOrangTua.TanggalLahirAyah = updateDataAnakDto.TanggalLahirAyah;
                anak.RiwayatOrangTua.PekerjaanAyah = updateDataAnakDto.PekerjaanAyah;
                anak.RiwayatOrangTua.NamaIbu = updateDataAnakDto.NamaIbu;
                anak.RiwayatOrangTua.TanggalLahirIbu = updateDataAnakDto.TanggalLahirIbu;
                anak.RiwayatOrangTua.PekerjaanIbu = updateDataAnakDto.PekerjaanIbu;
                anak.RiwayatOrangTua.PenghasilanOrangTua = updateDataAnakDto.PenghasilanOrangTua;
                anak.RiwayatOrangTua.AnggotaRumahTangga = updateDataAnakDto.AnggotaRumahTangga;
                anak.RiwayatOrangTua.TandaTanganPath = updateDataAnakDto.TandaTanganOrangTua;

                _context.Entry(anak).State = EntityState.Modified; 

                if(await _context.SaveChangesAsync() > 0)
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// Delete data anak based on specific dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>No Return</returns>
        [HttpDelete("{dataAnakId}")]
        public async Task<IActionResult> DeleteDataAnak(int dataAnakId)
        {
            try
            {
                var anak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kelahiran => kelahiran.RiwayatKelahiran)
                    .Include(orangTua => orangTua.RiwayatOrangTua)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                    .Include(nakes => nakes.NakesUser)
                    .SingleAsync();
            
                if (anak == null) 
                    return BadRequest("Data Anak Tidak Ditemukan!");
                
                _context.Remove(anak);

                if(await _context.SaveChangesAsync() > 0)
                    return Ok();
                return BadRequest("Failed to Save Data in Data Base!");   
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}