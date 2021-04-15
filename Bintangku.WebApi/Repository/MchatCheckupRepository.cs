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
    public class MchatCheckupRepository : IMchatCheckupRepository
    {
        private ApplicationDataContext _context;
        public MchatCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list hasil pemeriksaan kesehatan MCHAT anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>List hasil pemeriksaan kesehatan MCHAT anak</returns>
        public async Task<IEnumerable<MchatCheckup>> GetMchatCheckupAsync(int childDataId)
        {
            try
            {
                return await _context.MchatCheckups
                    .Where(child => child.ChildHealth.ChildDataId == childDataId)
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Post hasil pemeriksaan MCHAT anak to data base 
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="pemeriksaanMchatDto">Pemeriksaan MCHAT object</param>
        /// <returns>No return</returns>
        public async Task PostMchatCheckupAsync(
            int childDataId, PemeriksaanMchatDto pemeriksaanMchatDto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId)
                    .Include(health => health.ChildHealth)
                        .ThenInclude(check => check.MchatCheckups)
                    .SingleOrDefaultAsync();
                
                var result = new ResultMchat(pemeriksaanMchatDto);
                
                var mchat = new MchatCheckup
                {
                    Interpretasi = result.Interpretasi,
                    Intervensi = result.Intervensi,
                    TotalQuestionYes = result.TotalQuestionYes,
                    TotalQuestionNo = result.TotalQuestionNo,
                    TotalCriticalQuestionYes = result.TotalCirticalQuestionYes,
                    TotalCriticalQuestionNo = result.TotalCriticalQuestionNo,
                    Question1 = pemeriksaanMchatDto.Question1, 
                    Question2 = pemeriksaanMchatDto.Question2, 
                    Question3 = pemeriksaanMchatDto.Question3, 
                    Question4 = pemeriksaanMchatDto.Question4, 
                    Question5 = pemeriksaanMchatDto.Question5, 
                    Question6 = pemeriksaanMchatDto.Question6, 
                    Question7 = pemeriksaanMchatDto.Question7, 
                    Question8 = pemeriksaanMchatDto.Question8, 
                    Question9 = pemeriksaanMchatDto.Question9, 
                    Question10 = pemeriksaanMchatDto.Question10, 
                    Question11 = pemeriksaanMchatDto.Question11, 
                    Question12 = pemeriksaanMchatDto.Question12, 
                    Question13 = pemeriksaanMchatDto.Question13, 
                    Question14 = pemeriksaanMchatDto.Question14, 
                    Question15 = pemeriksaanMchatDto.Question15, 
                    Question16 = pemeriksaanMchatDto.Question16, 
                    Question17 = pemeriksaanMchatDto.Question17, 
                    Question18 = pemeriksaanMchatDto.Question18, 
                    Question19 = pemeriksaanMchatDto.Question19, 
                    Question20 = pemeriksaanMchatDto.Question20, 
                    Question21 = pemeriksaanMchatDto.Question21, 
                    Question22 = pemeriksaanMchatDto.Question22, 
                    Question23 = pemeriksaanMchatDto.Question23, 
                };

                childData.ChildHealth.MchatCheckups.Add(mchat);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Save all changes to data base
        /// </summary>
        /// <returns>No return</returns>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}