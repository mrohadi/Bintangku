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
    public class PemeriksaanLingkarKepalaRepository : IPemeriksaanLingkarKepalaRepository
    {
        private ApplicationDataContext _context;
        public PemeriksaanLingkarKepalaRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PemeriksaanLingkarKepala>> GetLingkarKepalaAsync(
            int dataAnakId)
        {
            try
            {
                return await _context.PemeriksaanLingkarKepalas
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId) 
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task PostLingkatKepalaAsync(int dataAnakId, PemeriksaanLingkarKepalaDto dto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(kepala => kepala.PemeriksaanLingkarKepalas)
                    .SingleOrDefaultAsync();
            
                var result = new ResultLingkarKepala(dto);

                var lingkarKepala = new PemeriksaanLingkarKepala
                {
                    LingkarKepala = dto.LingkarKepala,
                    Kurva = dto.Kurva,
                    Klasifikasi = result.Klasifikasi,
                    Tindakan = result.Tindakan 
                };
                
                dataAnak.KesehatanAnak.PemeriksaanLingkarKepalas.Add(lingkarKepala);
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