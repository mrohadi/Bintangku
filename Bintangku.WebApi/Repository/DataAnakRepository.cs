using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;
using Bintangku.WebApi.Extensions;

namespace Bintangku.WebApi.Repository
{
    public class DataAnakRepository : IDataAnakRepository
    {
        private readonly ApplicationDataContext _context;
        public DataAnakRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task DeleteDataAnakAsync(int dataAnakId)
        {
            try
            {
                DataAnak dataAnakToDelete = await _context.DataAnaks
                    .Where(x => x.DataAnakId == dataAnakId)
                    .Include(x => x.RiwayatKelahiran)
                    .Include(x => x.RiwayatOrangTua)
                    .Include(x => x.KesehatanAnak)
                    .Include(x => x.ImunisasiAnak)
                    .Include(x => x.NakesUser)
                    .SingleOrDefaultAsync();

                _context.Remove(dataAnakToDelete);    
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<DataAnakDto> GetDataAnakAsync(int dataAnakId)
        {
            try
            {
                DataAnak dataAnak = await _context.DataAnaks
                    .Where(x => x.DataAnakId == dataAnakId)
                    .Include(x => x.RiwayatOrangTua)
                    .SingleOrDefaultAsync();
            
                DataAnakDto dataAnakToReturn = new()
                {
                    Id = dataAnak.DataAnakId,
                    NamaLengkap = dataAnak.NamaLengkap,
                    NIK = dataAnak.NIK,
                    JenisKelamin = dataAnak.JenisKelamin,
                    ImagePath = dataAnak.ImagePath,
                    TanggalLahirAnak = dataAnak.TanggalLahirAnak,
                    NamaAyah = dataAnak.RiwayatOrangTua.NamaAyah,
                    NamaIbu = dataAnak.RiwayatOrangTua.NamaIbu,
                    Alamat = dataAnak.Alamat,
                    Kontak = dataAnak.Kontak
                };

                return dataAnakToReturn;    
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DataAnakDto>> GetDataAnaksAsync()
        {
            try
            {
                List<DataAnak> dataAnak = await _context.DataAnaks
                    .Include(x => x.RiwayatOrangTua) 
                    .ToListAsync();
                
                List<DataAnakDto> dataAnakToReturn = new();

                foreach (var anak in dataAnak)
                {
                    DataAnakDto anakDto = new()
                    {
                        Id = anak.DataAnakId,
                        NamaLengkap = anak.NamaLengkap,
                        NIK = anak.NIK,
                        JenisKelamin = anak.JenisKelamin,
                        ImagePath = anak.ImagePath,
                        TanggalLahirAnak = anak.TanggalLahirAnak,
                        UmurAnak = anak.UmurAnak,
                        NamaAyah = anak.RiwayatOrangTua.NamaAyah,
                        NamaIbu = anak.RiwayatOrangTua.NamaIbu,
                        Alamat = anak.Alamat,
                        Kontak = anak.Kontak
                    };

                    dataAnakToReturn.Add(anakDto);
                }

                return dataAnakToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task PostDataAnakAsync(string nakesUsername, PostDataAnakDto dto)
        {
            try
            {
                var currentNakes =  _context.Users
                    .SingleOrDefaultAsync(x => x.UserName == nakesUsername);

                DataAnak dataAnakToPost = new()
                {
                    NamaLengkap = dto.NamaLengkap,
                    NIK = dto.NIK,
                    JenisKelamin = dto.JenisKelaminAnak,
                    TanggalLahirAnak = dto.TanggalLahirAnak,
                    Alamat = dto.Alamat,
                    Kontak = dto.Kontak,
                    ImagePath = dto.ImagePath,
                    JumlahSaudara = dto.JumlahSaudara,
                    // Riwayat kelahiran
                    RiwayatKelahiran = new()
                    {
                        BeratBadan = dto.BeratBadan,
                        PanjangLahir = dto.PanjangLahir,
                        ApgarScore = dto.ApgarScore,
                        KelahiranDibantuOleh = dto.KelahiranDibantuOleh,
                        LainLain = dto.LainLain
                    },
                    // Riwayat orang tua
                    RiwayatOrangTua = new()
                    {
                        NamaAyah = dto.NamaAyah,
                        TanggalLahirAyah = dto.TanggalLahirAyah,
                        PekerjaanAyah = dto.PekerjaanAyah,
                        NamaIbu = dto.NamaIbu,
                        TanggalLahirIbu = dto.TanggalLahirIbu,
                        PekerjaanIbu = dto.PekerjaanIbu,
                        PenghasilanOrangTua = dto.PenghasilanOrangTua,
                        AnggotaRumahTangga = dto.AnggotaRumahTangga,
                        TandaTanganPath = dto.TandaTanganPath
                    },
                    // Kesehatan anak
                    KesehatanAnak = new()
                    {
                        PemeriksaanGpphs = new List<PemeriksaanGpph> { },
                        PemeriksaanMchats = new List<PemeriksaanMchat> { },
                        PemeriksaanKmpes = new List<PemeriksaanKmpe> { },
                    },
                    // Imunisasi anak
                    ImunisasiAnak = new ImunisasiAnak
                    {
                        ImunisasiHepatitisB = new ImunisasiHepatitisB { },
                        ImunisasiPolio = new ImunisasiPolio { },
                        ImunisasiBCG = new ImunisasiBCG { },
                        ImunisasiDTP = new ImunisasiDTP { },
                        ImunisasiHib = new ImunisasiHib { },
                        ImunisasiPCV = new ImunisasiPCV { },
                        ImunisasiRotavirus = new ImunisasiRotavirus { },
                        ImunisasiInfluenza = new ImunisasiInfluenza { },
                        ImunisasiCampak = new ImunisasiCampak { },
                        ImunisasiMMR = new ImunisasiMMR { },
                        ImunisasiTifoid = new ImunisasiTifoid { },
                        ImunisasiHepatitisA = new ImunisasiHepatitisA { },
                        ImunisasiVarisela = new ImunisasiVarisela { },
                        ImunisasiHPV = new ImunisasiHPV { },
                        ImunisasiJapaneseEncephalitis = new ImunisasiJapaneseEncephalitis { },
                        ImunisasiDengue = new ImunisasiDengue { } 
                    },
                    NakesUser = currentNakes.Result
                };

                dataAnakToPost.UmurAnak = dataAnakToPost.TanggalLahirAnak.CalculateAgeAnak();

                await _context.AddAsync(dataAnakToPost);
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        public async Task UpdateDataAnakAsync(int dataAnakId, DataAnak dataAnak)
        {
            try
            {
                DataAnak dataAnakToUpdate = await _context.DataAnaks
                    .SingleOrDefaultAsync(x => x.DataAnakId == dataAnakId);

                dataAnakToUpdate.NamaLengkap = dataAnak.NamaLengkap;
                dataAnakToUpdate.NIK = dataAnak.NIK;
                dataAnakToUpdate.JenisKelamin = dataAnak.JenisKelamin;
                dataAnakToUpdate.TanggalLahirAnak = dataAnak.TanggalLahirAnak;
                dataAnakToUpdate.Alamat = dataAnak.Alamat;
                dataAnakToUpdate.Kontak = dataAnak.Kontak;
                dataAnakToUpdate.ImagePath = dataAnak.ImagePath;
                dataAnakToUpdate.JumlahSaudara = dataAnak.JumlahSaudara;

                _context.Entry(dataAnakToUpdate).State = EntityState.Modified;    
            }
            catch (System.Exception)
            {    
                throw;
            }
               
        }
    }
}