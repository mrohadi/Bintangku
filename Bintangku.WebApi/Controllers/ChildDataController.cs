using System;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Extensions;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class ChildDataController : BaseApiController
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public ChildDataController(
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
        [HttpGet("child-data")]
        public async Task<ActionResult<IEnumerable<ChildData>>> GetChildData()
        {
            try
            {
                var dataAnak = await _context.ChildDatas
                    .Select(anak => new
                    {   
                        DataAnakId = anak.ChildDataId,
                        NamaLengkap = anak.FullName,
                        Nik = anak.NIK,
                        JenisKelaminAnak = anak.Gender,
                        TanggalLahirAnak = anak.DateOfBirth,
                        Alamat = anak.Address,
                        RiwayatKelahiran = anak.BirthHistory,
                        RiwayatOrangTua = anak.ParentHistory,
                        Kontak = anak.Kontak,
                        ImagePath = anak.ImagePath,
                        JumlahSaudara = anak.NumberOfSiblings,
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
        [HttpGet("child-data/{id}")]
        public async Task<ActionResult<ChildData>> GetDataAnak(int id)
        {
            try
            {
                var dataAnak = await _context.ChildDatas
                    .Where(x => x.ChildDataId == id)
                    .Select(anak => new 
                    {
                        DataAnakId = anak.ChildDataId,
                        NamaLengkap = anak.FullName,
                        Nik = anak.NIK,
                        JenisKelaminAnak = anak.Gender,
                        TanggalLahirAnak = anak.DateOfBirth,
                        Alamat = anak.Address,
                        Kontak = anak.Kontak,
                        ImagePath = anak.ImagePath,
                        JumlahSaudara = anak.NumberOfSiblings,
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
        [HttpPost("child-data")]
        public async Task<IActionResult> PostChildData(
            [FromBody] PostDataAnakDto postDataAnakDto)
        {
            try
            {
                var currentNakesUsername = User.GetUserName();
                var currentNakes = _context.Users.SingleOrDefaultAsync(
                    x => x.UserName == currentNakesUsername);

                var dataToPost = new ChildData
                {
                    FullName = postDataAnakDto.NamaLengkap,
                    NIK = postDataAnakDto.NIK,
                    Gender = postDataAnakDto.JenisKelaminAnak,
                    DateOfBirth = postDataAnakDto.TanggalLahirAnak,
                    Address = postDataAnakDto.Alamat,
                    Kontak = postDataAnakDto.Kontak,
                    ImagePath = postDataAnakDto.ImagePath,
                    NumberOfSiblings = postDataAnakDto.JumlahSaudara,
                    // Riwayat Kelahiran
                    BirthHistory = new BirthHistory
                    {
                        Weight = postDataAnakDto.BeratBadan,
                        Length = postDataAnakDto.PanjangLahir,
                        ApgarScore = postDataAnakDto.ApgarScore,
                        BirthAssistedBy  = postDataAnakDto.KelahiranDibantuOleh,
                        Etc = postDataAnakDto.LainLain,
                    },
                    // Riwayat Orang Tua
                    ParentHistory = new ParentHistory
                    {
                        FatherName = postDataAnakDto.NamaAyah,
                        FatherDateOfBirth = postDataAnakDto.TanggalLahirAyah,
                        FatherJob = postDataAnakDto.PekerjaanAyah,
                        MotherName = postDataAnakDto.NamaIbu,
                        MotherDateOfBirth = postDataAnakDto.TanggalLahirIbu,
                        MotherJob = postDataAnakDto.PekerjaanIbu,
                        ParentIncome = postDataAnakDto.PenghasilanOrangTua,
                        HouseholdMember = postDataAnakDto.AnggotaRumahTangga,
                        SignaturePath = postDataAnakDto.TandaTanganPath
                    },
                    ChildHealth = new ChildHealth
                    {
                        GpphCheckups = new List<GpphCheckup> { },
                        MchatCheckups = new List<MchatCheckup> { },
                        KmpeCheckups = new List<KmpeCheckup> { }
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
        [HttpPut("child-data/{dataAnakId}")]
        public async Task<IActionResult> UpdateChildData(
            int dataAnakId, [FromBody]UpdateDataAnakDto updateDataAnakDto)
        {
            try
            {
                var anak = await _context.ChildDatas
                .SingleOrDefaultAsync(anak => anak.ChildDataId == dataAnakId);
            
                if (anak == null) 
                    return BadRequest("Data Anak Tidak Ditemukan");
                
                // Update Prfile Anak
                anak.FullName = updateDataAnakDto.NamaLengkap;
                anak.NIK = updateDataAnakDto.NIK;
                anak.Gender = updateDataAnakDto.JenisKelaminAnak;
                anak.DateOfBirth = updateDataAnakDto.TanggalLahirAnak;
                anak.Address = updateDataAnakDto.Alamat;
                anak.Kontak = updateDataAnakDto.Kontak;
                anak.ImagePath = updateDataAnakDto.ImagePath; 
                anak.NumberOfSiblings = updateDataAnakDto.JumlahSaudara;

                // Update Riwayat Kelahiran Data
                anak.BirthHistory.Weight = updateDataAnakDto.BeratBadan;
                anak.BirthHistory.Length = updateDataAnakDto.PanjangLahir;
                anak.BirthHistory.ApgarScore = updateDataAnakDto.ApgarScore;
                anak.BirthHistory.BirthAssistedBy = updateDataAnakDto.KelahiranDibantuOleh;
                anak.BirthHistory.Etc = updateDataAnakDto.LainLain;

                // Update Riwayat Orang Tua Data
                anak.ParentHistory.FatherName = updateDataAnakDto.NamaAyah;
                anak.ParentHistory.FatherDateOfBirth = updateDataAnakDto.TanggalLahirAyah;
                anak.ParentHistory.FatherJob = updateDataAnakDto.PekerjaanAyah;
                anak.ParentHistory.MotherName = updateDataAnakDto.NamaIbu;
                anak.ParentHistory.MotherDateOfBirth = updateDataAnakDto.TanggalLahirIbu;
                anak.ParentHistory.MotherJob = updateDataAnakDto.PekerjaanIbu;
                anak.ParentHistory.ParentIncome = updateDataAnakDto.PenghasilanOrangTua;
                anak.ParentHistory.HouseholdMember = updateDataAnakDto.AnggotaRumahTangga;
                anak.ParentHistory.SignaturePath = updateDataAnakDto.TandaTanganOrangTua;

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
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>No Return</returns>
        [HttpDelete("child-data/{childDataId}")]
        public async Task<IActionResult> DeleteChildData(int childDataId)
        {
            try
            {
                var anak = await _context.ChildDatas
                    .Where(anak => anak.ChildDataId == childDataId)
                    .Include(birth => birth.BirthHistory)
                    .Include(orangTua => orangTua.ParentHistory)
                    .Include(health => health.ChildHealth)
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