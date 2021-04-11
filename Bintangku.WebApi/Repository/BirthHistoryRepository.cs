using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository
{
    public class BirthHistoryRepository : IBirthHistoryRepository
    {
        private ApplicationDataContext _context;
        public BirthHistoryRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<BirthHistory> GetBirthHistoryAsync(int childDataId)
        {
            try
            {
                return await _context.BirthHistories
                    .Where(child => child.ChildDataId == childDataId)
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

        public void Update(BirthHistory birthHistory)
        {
            throw new System.NotImplementedException();
        }
    }
}