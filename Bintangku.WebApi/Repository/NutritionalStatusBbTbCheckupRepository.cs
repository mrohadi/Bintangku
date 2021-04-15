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
    public class NutritionalStatusBbTbCheckupRepository : INutritionalStatusBbTbCheckupRepository
    {
        private ApplicationDataContext _context;
        public NutritionalStatusBbTbCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<NutritionalStatusBbTbCheckup>> GetNutritionalStatusBbTbCheckupsAsync(int childDataId)
        {
            try
            {
                return await _context.NutritionalStatusBbTbCheckups
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
        /// <param name="giziBbTbDto"></param>
        /// <returns></returns>
        public async Task PostNutritionalStatusBbTbCheckupAsync(int childDataId, PemeriksaanStatusGiziBbTbDto giziBbTbDto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId)
                    .Include(health => health.ChildHealth)
                        .ThenInclude(check => check.NutritionalStatusBbTbCheckups)
                    .SingleOrDefaultAsync();
            
                var result = new ResultStatusGiziBbTb(giziBbTbDto);

                var bbTbCheckup = new NutritionalStatusBbTbCheckup
                {
                    Weight = giziBbTbDto.BeratBadan,
                    Height = giziBbTbDto.TinggiBadan,
                    ZCode = giziBbTbDto.ZCode,
                    NutritionalStatus = result.StatusGizi,
                    Action = result.Tindakan 
                };
                
                childData.ChildHealth.NutritionalStatusBbTbCheckups.Add(bbTbCheckup);
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

        public void Update(PemeriksaanStatusGiziBbTbDto giziBbTbDto)
        {
            throw new System.NotImplementedException();
        }

        public void Update(NutritionalStatusBbTbCheckup bbTbCheckup)
        {
            throw new System.NotImplementedException();
        }
    }
}