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
    public class NutritionalStatusImtUCheckupRepository : INutritionalStatusImtUCheckupRepository
    {
        private ApplicationDataContext _context;
        public NutritionalStatusImtUCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<NutritionalStatusImtUCheckup>> GetNutritionalStatusImtUCheckupsAsync(int childDataId)
        {
            try
            {
                return await _context.NutritionalStatusImtUCheckups
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
        public async Task PostNutritionalStatusImtUCheckupAsync(int childDataId, PemeriksaanStatusGiziImtUDto dto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId)
                    .Include(health => health.ChildHealth)
                        .ThenInclude(gizi => gizi.NutritionalStatusImtUCheckups)
                    .SingleOrDefaultAsync();
                
                var result = new ResultStatusGiziImtU(dto);
                
                var nutritionalImtU = new NutritionalStatusImtUCheckup
                {
                    Weight = dto.BeratBadan,
                    Height= dto.TinggiBadan,
                    Age = dto.Umur,
                    ZCode = dto.ZCode,
                    IMT = result.IMT,
                    NutritionalStatus = result.StatusGizi,
                    Action = result.Tindakan 
                };
                
                childData.ChildHealth.NutritionalStatusImtUCheckups.Add(nutritionalImtU);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0; 
        }

        public void Upload(PemeriksaanStatusGiziImtUDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}