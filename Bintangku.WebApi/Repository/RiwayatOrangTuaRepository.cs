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
            return await _context.RiwayatOrangTuas
                .SingleOrDefaultAsync(anak => anak.DataAnakId == dataAnakId);
        }

        public void Update(RiwayatOrangTua riwayatOrangTua)
        {
            throw new System.NotImplementedException();
        }
    }
}