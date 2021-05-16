using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository
{
    public class RiwayatKelahiranRepository : IRiwayatKelahiranRepository
    {
        private readonly ApplicationDataContext _context;
        public RiwayatKelahiranRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<RiwayatKelahiran> GetRiwayatKelahiran(int dataAnakId)
        {
            try
            {
                RiwayatKelahiran kelahiran = await _context.RiwayatKelahirans
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync(); 

                return kelahiran;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateRiwayatKelahiran(int dataAnakId, RiwayatKelahiran riwayatKelahiran)
        {
            RiwayatKelahiran riwayat = await _context.RiwayatKelahirans
                .Where(x => x.DataAnakId == dataAnakId)
                .SingleOrDefaultAsync();

            riwayat.BeratBadan = riwayatKelahiran.BeratBadan;
            riwayat.PanjangLahir = riwayatKelahiran.PanjangLahir;
            riwayat.ApgarScore = riwayatKelahiran.ApgarScore;
            riwayat.KelahiranDibantuOleh = riwayatKelahiran.KelahiranDibantuOleh;
            riwayat.LainLain = riwayatKelahiran.LainLain;

            _context.Entry(riwayat).State = EntityState.Modified;
        }
    }
}