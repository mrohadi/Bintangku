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
        private ApplicationDataContext _context;
        public RiwayatKelahiranRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<RiwayatKelahiran> GetRiwayatKelahiran(int dataAnakId)
        {
            try
            {
                return await _context.RiwayatKelahirans
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(RiwayatKelahiran riwayatKelahiran)
        {
            throw new System.NotImplementedException();
        }
    }
}