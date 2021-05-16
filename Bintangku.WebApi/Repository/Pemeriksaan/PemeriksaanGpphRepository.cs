using System;
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
    public class PemeriksaanGpphRepository : IPemeriksaanGpphRepository
    {
        private readonly ApplicationDataContext _context;
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
                var gpph =await _context.PemeriksaanGpphs
                    .Where(x => x.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync(); 

                return gpph; 
            }
            catch (Exception)
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
                
                var hasilGpph = new ResultGpph(pemeriksaanGpphDto);
                
                var pemeriksaanGpph = new PemeriksaanGpph 
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

                dataAnak.KesehatanAnak.PemeriksaanGpphs.Add(pemeriksaanGpph);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}