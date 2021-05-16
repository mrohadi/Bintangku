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
    public class PemeriksaanStatusGiziImtURepository : IPemeriksaanStatusGiziImtURepository
    {
        private readonly ApplicationDataContext _context;
        public PemeriksaanStatusGiziImtURepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PemeriksaanStatusGiziImtU>> GetStatusGiziImtUAsync(int dataAnakId)
        {
            try
            {
                var giziImtU = await _context.PemeriksaanStatusGiziImtUs
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync();

                return giziImtU; 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task PostStatusGiziImtUAsync(int dataAnakId, PemeriksaanStatusGiziImtUDto dto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(gizi => gizi.PemeriksaanStatusGiziImtUs)
                    .SingleOrDefaultAsync();
                
                var resultGiziImtU = new ResultStatusGiziImtU(dto);
                
                var giziImtU = new PemeriksaanStatusGiziImtU
                {
                    BeratBadan = dto.BeratBadan,
                    TinggiBadan = dto.TinggiBadan,
                    Umur = dto.Umur,
                    ZCode = dto.ZCode,
                    IMT = resultGiziImtU.IMT,
                    StatusGizi = resultGiziImtU.StatusGizi,
                    Tindakan = resultGiziImtU.Tindakan 
                };
                
                dataAnak.KesehatanAnak.PemeriksaanStatusGiziImtUs.Add(giziImtU);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Upload(PemeriksaanStatusGiziImtUDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}