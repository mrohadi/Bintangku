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
    public class NutritionalStatusIpTbCheckupRepository : INutritionalStatusIpTbCheckupRepository
    {
        private ApplicationDataContext _context;
        public NutritionalStatusIpTbCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<NutritionalStatusIpTbCheckup>> GetNutritionalStatusIpTbCheckupsAsync(
            int childDataId)
        {
            try
            {
                return await _context.NutritionalStatusIpTbCheckups
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
        public async Task PostNutritionalStatusIpTbChekcupAsync(int childDataId, PemeriksaanStatusGiziIpTbDto dto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId) 
                    .Include(health => health.ChildHealth)
                        .ThenInclude(nutri => nutri.NutritionalStatusIpTbCheckups)
                    .SingleOrDefaultAsync();
                
                var result = new ResultStatusGiziIpTb(dto);

                var ipTbCheckup = new NutritionalStatusIpTbCheckup
                {
                    Height = dto.TinggiBadan,
                    IndexLength = dto.IndeksPanjang,
                    ZCode = dto.ZCode,
                    NutritionalStatus = result.StatusGizi,
                    Action= result.Tindakan 
                };

                childData.ChildHealth.NutritionalStatusIpTbCheckups.Add(ipTbCheckup);
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
            try
            {
                return await _context.SaveChangesAsync() > 0;    
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Update(PemeriksaanStatusGiziIpTbDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}