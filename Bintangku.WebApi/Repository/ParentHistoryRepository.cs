using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository
{
    public class ParentHistoryRepository : IParentHistoryRepository
    {
        private ApplicationDataContext _context;
        public ParentHistoryRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        public async Task<ParentHistory> GetParentHistoryAsync(int childDataId)
        {
            return await _context.ParentHistories
                .SingleOrDefaultAsync(child => child.ChildDataId == childDataId);
        }

        public void Update(ParentHistory parentHistory)
        {
            throw new System.NotImplementedException();
        }
    }
}