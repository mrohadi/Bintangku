using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;
using Bintangku.WebApi.Interfaces.Pemeriksaan;
using Bintangku.WebApi.Pemeriksaan;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Pemeriksaan
{
    public class PemeriksaanLingkarKepalaRepository : IPemeriksaanLingkarKepalaRepository
    {
        private readonly ApplicationDataContext _context;
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
                var lingkarKepala = await _context.PemeriksaanLingkarKepalas
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId) 
                    .ToListAsync(); 

                return lingkarKepala; 
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

        public void Update(PemeriksaanLingkarKepalaDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}