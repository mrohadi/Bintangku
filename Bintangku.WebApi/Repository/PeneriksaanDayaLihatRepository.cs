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
    public class PemeriksaanDayaLihatRepository : IPemeriksaanDayaLihatRepository
    {
        private ApplicationDataContext _context;
        public PemeriksaanDayaLihatRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list tes daya lihat anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>List of tes daya lihat anak</returns>
        public async Task<IEnumerable<PemeriksaanDayaLihat>> GetTesDayaLihat(int dataAnakId)
        {
            try
            {
                return await _context.PemeriksaanDayaLihats
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)
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
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="tesDayaLihatDto">Data model tes daya lihat to post</param>
        /// <returns>No return</returns>
        public async Task PostDayaLihat(
            int dataAnakId, PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks 
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanDayaLihats)
                    .SingleOrDefaultAsync();
                
                var hasilTesDayaLihat = new ResultTesDayaLihat(pemeriksaanDayaLihatDto);
                
                var postDayaLihat = new PemeriksaanDayaLihat
                {
                    Interpretasi = hasilTesDayaLihat.Interpretasi,
                    Intervensi = hasilTesDayaLihat.Intervensi,
                    MataKanan = pemeriksaanDayaLihatDto.MataKanan,
                    MataKiri = pemeriksaanDayaLihatDto.MataKiri
                };
                
                dataAnak.KesehatanAnak.PemeriksaanDayaLihats.Add(postDayaLihat);
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
    }
}