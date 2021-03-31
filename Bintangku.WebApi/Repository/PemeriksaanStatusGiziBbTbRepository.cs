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
    public class PemeriksaanStatusGiziBbTbRepository : IPemeriksaanStatusGiziBbTbRepository
    {
        private ApplicationDataContext _context;
        public PemeriksaanStatusGiziBbTbRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PemeriksaanStatusGiziBbTb>> GetStatusGizi(int dataAnakId)
        {
            try
            {
                return await _context.PemeriksaanStatusGiziBbTbs
                    .Where(anak => anak.KesehatanAnak.DataAnakId == dataAnakId)
                    .ToListAsync();
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

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(PemeriksaanStatusGiziBbTbDto giziBbTbDto)
        {
            throw new System.NotImplementedException();
        }
    }
}