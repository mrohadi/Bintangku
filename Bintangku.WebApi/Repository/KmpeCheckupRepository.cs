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
    public class KmpeCheckupRepository : IKmpeCheckupRepository
    {
        private ApplicationDataContext _context;
        public KmpeCheckupRepository(ApplicationDataContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Get list data hasil pemeriksaan kesehatan KMPE anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Return list data hasil pemeriksaan kesehatan KMPE anak</returns>
        public async Task<IEnumerable<KmpeCheckup>> GetKmpeCheckupsAsync(int childDataId)
        {
            try
            {
                return await _context.KmpeCheckups   
                    .Where(child => child.ChildHealth.ChildDataId == childDataId)
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Post hasil pemeriksaan kesehatan KMPE child to data base
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="pemeriksaanKmpeDto">Data model to transfer to data base</param>
        /// <returns>No return</returns>
        public async Task PostKmpeCheckupAsync(
            int childDataId, PemeriksaanKmpeDto pemeriksaanKmpeDto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId) 
                    .Include(health => health.ChildHealth)
                        .ThenInclude(check => check.KpspCheckups)
                    .SingleOrDefaultAsync();
                
                var result = new ResultKmpe(pemeriksaanKmpeDto);

                var kmpeResult = new KmpeCheckup
                {
                    TotalYes =  result.JumlahYa,
                    Interpretasi = result.Interpretasi,
                    Intervensi = result.Intervensi,
                    Question1 = pemeriksaanKmpeDto.Question1,
                    Question2 = pemeriksaanKmpeDto.Question2,
                    Question3 = pemeriksaanKmpeDto.Question3,
                    Question4 = pemeriksaanKmpeDto.Question4,
                    Question5 = pemeriksaanKmpeDto.Question5,
                    Question6 = pemeriksaanKmpeDto.Question6,
                    Question7 = pemeriksaanKmpeDto.Question7,
                    Question8 = pemeriksaanKmpeDto.Question8,
                    Question9 = pemeriksaanKmpeDto.Question9,
                    Question10 = pemeriksaanKmpeDto.Question10,
                    Question11 = pemeriksaanKmpeDto.Question11,
                    Question12 = pemeriksaanKmpeDto.Question12,
                    Question13 = pemeriksaanKmpeDto.Question13,
                };

                childData.ChildHealth.KmpeCheckups.Add(kmpeResult);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Save all changes in the data base
        /// </summary>
        /// <returns>No return</returns>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}