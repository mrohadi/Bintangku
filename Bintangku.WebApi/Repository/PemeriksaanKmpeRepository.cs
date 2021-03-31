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
    public class PemeriksaanKmpeRepository : IPemeriksaanKmpeRepository
    {
        private ApplicationDataContext _context;
        public PemeriksaanKmpeRepository(ApplicationDataContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// GET list data hasil pemeriksaan kesehatan KMPE anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Return list data hasil pemeriksaan kesehatan KMPE anak</returns>
        public async Task<IEnumerable<PemeriksaanKmpe>> GetPemeriksaanKmpe(int dataAnakId)
        {
            try
            {
                return await _context.PemeriksaanKmpes   
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// POST hasil pemeriksaan kesehatan KMPE anak to data base
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanKmpeDto">Data model to transfer to data base</param>
        /// <returns>No return</returns>
        public async Task PostPemeriksaanKmpe(int dataAnakId, PemeriksaanKmpeDto pemeriksaanKmpeDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId) 
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanKmpes)
                    .SingleOrDefaultAsync();
                
                var hasilKmpe = new ResultKmpe(pemeriksaanKmpeDto);

                var pemeriksaanKmpe = new PemeriksaanKmpe
                {
                    JumlahYa =  hasilKmpe.JumlahYa,
                    Interpretasi = hasilKmpe.Interpretasi,
                    Intervensi = hasilKmpe.Intervensi,
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

                dataAnak.KesehatanAnak.PemeriksaanKmpes.Add(pemeriksaanKmpe);
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