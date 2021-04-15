using System;
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
    public class GpphCheckupRepository : IGpphCheckupRepository
    {
        private ApplicationDataContext _context;
        public GpphCheckupRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get hasil pemeriksaan kesehatan GPPH anak
        /// </summary>
        /// <param name="childHealthId">Unique dataAnakId</param>
        /// <returns>Pemeriksaan kesehatan GPPH anak</returns>
        public async Task<IEnumerable<GpphCheckup>> GetGpphCheckupsAsync(int childHealthId)
        {
            try
            {
                return await _context.GpphCheckups
                    .Where(health => health.ChildHealthId == childHealthId)
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Post 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        public async Task PostGpphCheckupAsync(
            int childDataId, PemeriksaanGpphDto pemeriksaanGpphDto)
        {
            try
            {
                var childData = await _context.ChildDatas
                    .Where(child => child.ChildDataId == childDataId)
                    .Include(health => health.ChildHealth)
                        .ThenInclude(check => check.GpphCheckups)
                    .SingleOrDefaultAsync();
                
                var hasilGpph = new ResultGpph(pemeriksaanGpphDto);
                
                var pemeriksaanGpph = new GpphCheckup 
                { 
                    Point = hasilGpph.Point,
                    Interpretasi = hasilGpph.Interpretasi,
                    Intervensi = hasilGpph.Intervensi,
                    Question1 = pemeriksaanGpphDto.Question1,
                    Question2 = pemeriksaanGpphDto.Question2,
                    Question3 = pemeriksaanGpphDto.Question3,
                    Question4 = pemeriksaanGpphDto.Question4,
                    Question5 = pemeriksaanGpphDto.Question5,
                    Question6 = pemeriksaanGpphDto.Question6,
                    Question7 = pemeriksaanGpphDto.Question7,
                    Question8 = pemeriksaanGpphDto.Question8,
                    Question9 = pemeriksaanGpphDto.Question9,
                    Question10 = pemeriksaanGpphDto.Question10,
                };

                childData.ChildHealth.GpphCheckups.Add(pemeriksaanGpph);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Save all update in data base 
        /// </summary>
        /// <returns>No return</returns>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}