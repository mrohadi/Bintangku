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
    public class VisionCheckupRepository : IVisionCheckupRepository
    {
        private ApplicationDataContext _context;
        public VisionCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list tes daya lihat anak
        /// </summary>
        /// <param name="childDataId">Unique dataAnakId</param>
        /// <returns>List of tes daya lihat anak</returns>
        public async Task<IEnumerable<VisionCheckup>> GetVisionCheckupsAsync    (int childDataId)
        {
            try
            {
                return await _context.VisionCheckups
                    .Where(child => child.ChildHealth.ChildDataId == childDataId)
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            } 
        }

        /// <summary>
        /// Post tes daya lihat anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="tesDayaLihatDto">Data model tes daya lihat to post</param>
        /// <returns>No return</returns>
        public async Task PostVisionCheckupAsync(
            int childDataId, PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId)
                    .Include(health => health.ChildHealth)
                        .ThenInclude(check => check.VisionCheckups)
                    .SingleOrDefaultAsync();
                
                var result = new ResultVisionCheckup(pemeriksaanDayaLihatDto);
                
                var postDayaLihat = new VisionCheckup
                {
                    Interpretasi = result.Interpretasi,
                    Intervensi = result.Intervensi,
                    RightEye = pemeriksaanDayaLihatDto.MataKanan,
                    LeftEye = pemeriksaanDayaLihatDto.MataKiri
                };
                
                childData.ChildHealth.VisionCheckups.Add(postDayaLihat);
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

        public void Update(PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto)
        {
            throw new System.NotImplementedException();
        }

        public void Update(VisionCheckup visionCheckup)
        {
            throw new System.NotImplementedException();
        }
    }
}