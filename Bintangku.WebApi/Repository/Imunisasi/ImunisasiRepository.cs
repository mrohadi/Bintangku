using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiRepository : IImunisasiRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ImunisasiAnak>> GetImunisasiAsync()
        {
            try
            {
                var imunisasi = await _context.ImunisasiAnaks
                    .Include(x => x.ImunisasiHepatitisB)
                    .Include(x => x.ImunisasiPolio)
                    .Include(x => x.ImunisasiBCG)
                    .Include(x => x.ImunisasiDTP)
                    .Include(x => x.ImunisasiPCV)
                    .Include(x => x.ImunisasiRotavirus)
                    .Include(x => x.ImunisasiInfluenza)
                    .Include(x => x.ImunisasiCampak)
                    .Include(x => x.ImunisasiMMR)
                    .Include(x => x.ImunisasiTifoid)
                    .Include(x => x.ImunisasiHepatitisA)
                    .Include(x => x.ImunisasiVarisela)
                    .Include(x => x.ImunisasiJapaneseEncephalitis)
                    .Include(x => x.ImunisasiDengue)
                    .ToListAsync();

                return imunisasi;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // public async Task<IEnumerable<ImunisasiAnak>> GetImunisasisAsync()
        // {
        //     try
        //     {
        //         var imunisasis = await _context.ImunisasiAnaks

        //     }
        //     catch (System.Exception)
        //     {
                
        //         throw;
        //     }
        // }
    }
}