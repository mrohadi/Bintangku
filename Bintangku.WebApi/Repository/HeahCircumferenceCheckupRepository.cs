using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Pemeriksaan;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository
{
    public class HeadCircumferenceCheckupRepository : IHeadCircumferenceCheckupRepository
    {
        private ApplicationDataContext _context;
        public HeadCircumferenceCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<HeadCircumferenceCheckup>> GetHeadCircumferenceCheckupAsync(
            int childDataId)
        {
            try
            {
                return await _context.HeadCircumferenceCheckups
                    .Where(child => child.ChildHealth.ChildDataId == childDataId) 
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task PostHeadCircumferenceCheckupAsync(int childDataId, PemeriksaanLingkarKepalaDto dto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId)
                    .Include(health => health.ChildHealth)
                        .ThenInclude(kepala => kepala.HeadCircumferenceCheckups)
                    .SingleOrDefaultAsync();
            
                var result = new ResultLingkarKepala(dto);

                var headCircum = new HeadCircumferenceCheckup
                {
                    HeadCircumference = dto.LingkarKepala,
                    Curve = dto.Kurva,
                    Classification = result.Klasifikasi,
                    Action = result.Tindakan 
                };
                
                childData.ChildHealth.HeadCircumferenceCheckups.Add(headCircum);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(PemeriksaanLingkarKepalaDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}