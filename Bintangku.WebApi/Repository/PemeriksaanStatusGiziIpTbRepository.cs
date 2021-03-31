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
    public class PemeriksaanStatusGiziIpTbRepository : IPemeriksaanStatusGiziIpTbRepository
    {
        private ApplicationDataContext _context;
        public PemeriksaanStatusGiziIpTbRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PemeriksaanStatusGiziIpTb>> GetStatusGiziIpTbAsync(
            int dataAnakId)
        {
            try
            {
                return await _context.PemeriksaanStatusGiziIpTbs
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId) 
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
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task PostStatusGiziIpTbAsync(int dataAnakId, PemeriksaanStatusGiziIpTbDto dto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId) 
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(gizi => gizi.PemeriksaanStatusGiziIpTbs)
                    .SingleOrDefaultAsync();
                
                var resultGiziIpTb = new ResultStatusGiziIpTb(dto);

                var statusGiziIpTb = new PemeriksaanStatusGiziIpTb
                {
                    TinggiBadan = dto.TinggiBadan,
                    IndeksPanjang = dto.IndeksPanjang,
                    ZCode = dto.ZCode,
                    StatusGizi = resultGiziIpTb.StatusGizi,
                    Tindakan = resultGiziIpTb.Tindakan 
                };

                dataAnak.KesehatanAnak.PemeriksaanStatusGiziIpTbs.Add(statusGiziIpTb);
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