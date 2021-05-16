using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository
{
    public class RiwayatOrangTuaRepository : IRiwayatOrangTuaRepository
    {
        private ApplicationDataContext _context;
        public RiwayatOrangTuaRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<RiwayatOrangTua> GetRiwayatOrangTuaAsync(int dataAnakId)
        {
            try
            {
                RiwayatOrangTua riwayatOrangTua =  await _context.RiwayatOrangTuas
                    .SingleOrDefaultAsync(anak => anak.DataAnakId == dataAnakId);    
                
                return riwayatOrangTua;
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        public async Task UpdateRiwayatOrangTuaAsync(int dataAnakId, RiwayatOrangTua riwayatOrangTua)
        {
            try
            {
                RiwayatOrangTua orangTua = await _context.RiwayatOrangTuas
                    .Where(x => x.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();

                orangTua.NamaAyah = riwayatOrangTua.NamaAyah;
                orangTua.TanggalLahirAyah = riwayatOrangTua.TanggalLahirAyah;
                orangTua.PekerjaanAyah = riwayatOrangTua.PekerjaanAyah;
                orangTua.NamaIbu = riwayatOrangTua.NamaIbu;
                orangTua.TanggalLahirIbu = riwayatOrangTua.TanggalLahirIbu;
                orangTua.PekerjaanIbu = riwayatOrangTua.PekerjaanIbu;
                orangTua.PekerjaanIbu = riwayatOrangTua.PekerjaanIbu;
                orangTua.PenghasilanOrangTua = riwayatOrangTua.PenghasilanOrangTua;
                orangTua.AnggotaRumahTangga = riwayatOrangTua.AnggotaRumahTangga;
                orangTua.TandaTanganPath = riwayatOrangTua.TandaTanganPath; 

                _context.Entry(orangTua).State = EntityState.Modified;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}