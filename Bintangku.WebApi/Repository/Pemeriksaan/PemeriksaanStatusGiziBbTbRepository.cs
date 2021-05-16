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
    public class PemeriksaanStatusGiziBbTbRepository : IPemeriksaanStatusGiziBbTbRepository
    {
        private readonly ApplicationDataContext _context;
        public PemeriksaanStatusGiziBbTbRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PemeriksaanStatusGiziBbTb>> GetStatusGizi(int dataAnakId)
        {
            try
            {
                var giziBbTb = await _context.PemeriksaanStatusGiziBbTbs
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync(); 

                return giziBbTb; 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task PostPemeriksaanStatusGiziBbTb(int dataAnakId, PemeriksaanStatusGiziBbTbDto giziBbTbDto)
        {
            try
            {
                var dataAnak = await _context.DataAnaks
                    .Where(anak => anak.DataAnakId == dataAnakId)
                    .Include(kesehatan => kesehatan.KesehatanAnak)
                        .ThenInclude(pemeriksaan => pemeriksaan.PemeriksaanStatusGiziBbTbs)
                    .SingleOrDefaultAsync();
            
                var resultStatusGiziBbTb = new ResultStatusGiziBbTb(giziBbTbDto);

                var statusGiziBbTb = new PemeriksaanStatusGiziBbTb
                {
                    BeratBadan = giziBbTbDto.BeratBadan,
                    TinggiBadan = giziBbTbDto.TinggiBadan,
                    ZCode = giziBbTbDto.ZCode,
                    StatusGizi = resultStatusGiziBbTb.StatusGizi,
                    Tindakan = resultStatusGiziBbTb.Tindakan 
                };
                
                dataAnak.KesehatanAnak.PemeriksaanStatusGiziBbTbs.Add(statusGiziBbTb);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Update(PemeriksaanStatusGiziBbTbDto giziBbTbDto)
        {
            throw new System.NotImplementedException();
        }
    }
}