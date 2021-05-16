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
    public class PemeriksaanMchatRepository : IPemeriksaanMchatRepository
    {
        private readonly ApplicationDataContext _context;
        public PemeriksaanMchatRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list hasil pemeriksaan kesehatan MCHAT anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>List hasil pemeriksaan kesehatan MCHAT anak</returns>
        public async Task<IEnumerable<PemeriksaanMchat>> GetPemeriksaanMchat(int dataAnakId)
        {
            try
            {
                var mchat = await _context.PemeriksaanMchats
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync(); 

                return mchat; 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Post hasil pemeriksaan MCHAT anak to data base 
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanMchatDto">Pemeriksaan MCHAT object</param>
        /// <returns>No return</returns>
        public async Task PostPemeriksaanMchat(int dataAnakId, PemeriksaanMchatDto pemeriksaanMchatDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanMchats)
                    .SingleOrDefaultAsync();
                
                var resultMchat = new ResultMchat(pemeriksaanMchatDto);
                
                var pemeriksaanMchat = new PemeriksaanMchat
                {
                    Interpretasi = resultMchat.Interpretasi,
                    Intervensi = resultMchat.Intervensi,
                    TotalQuestionYes = resultMchat.TotalQuestionYes,
                    TotalQuestionNo = resultMchat.TotalQuestionNo,
                    TotalCriticalQuestionYes = resultMchat.TotalCirticalQuestionYes,
                    TotalCriticalQuestionNo = resultMchat.TotalCriticalQuestionNo,
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

                dataAnak.KesehatanAnak.PemeriksaanMchats.Add(pemeriksaanMchat);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}