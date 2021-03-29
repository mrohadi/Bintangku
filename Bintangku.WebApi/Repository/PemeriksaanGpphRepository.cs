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
    public class PemeriksaanGpphRepository : IPemeriksaanGpphRepository
    {
        private ApplicationDataContext _context;
        public PemeriksaanGpphRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET hasil pemeriksaan kesehatan GPPH anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Pemeriksaan kesehatan GPPH anak</returns>
        public async Task<IEnumerable<PemeriksaanGpph>> GetPemeriksaanGpph(int dataAnakId)
        {
            try
            {
                return await _context.PemeriksaanGpphs
                    .Where(x => x.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// POST 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        public async Task PostPemeriksaanGpph(
            int dataAnakId, PemeriksaanGpphDto pemeriksaanGpphDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanGpphs)
                    .SingleOrDefaultAsync();
                
                var hasilGpph = new ResultGpph(pemeriksaanGpphDto.Point);
                
                var pemeriksaanGpph = new PemeriksaanGpph 
                { 
                    Point = pemeriksaanGpphDto.Point,
                    Interpretasi = hasilGpph.Interpretasi,
                    Intervensi = hasilGpph.Intervensi
                };

                dataAnak.KesehatanAnak.PemeriksaanGpphs.Add(pemeriksaanGpph);
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