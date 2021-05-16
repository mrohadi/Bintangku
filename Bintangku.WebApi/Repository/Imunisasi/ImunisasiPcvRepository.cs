using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiPcvRepository : IImunisasiPcvRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiPcvRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiPcvAsync(int dataAnakId)
        {
            try
            {
                var pcv = await _context.ImunisasiPCVs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var pcvToReturn = new ImunisasiDto
                {
                    Lahir = pcv.Lahir,
                    Bulan1 = pcv.Bulan1,
                    Bulan2 = pcv.Bulan2,
                    Bulan3 = pcv.Bulan3,
                    Bulan4 = pcv.Bulan4,
                    Bulan5 = pcv.Bulan5,
                    Bulan6 = pcv.Bulan6,
                    Bulan9 = pcv.Bulan9,
                    Bulan12 = pcv.Bulan12,
                    Bulan15 = pcv.Bulan15,
                    Bulan18 = pcv.Bulan18,
                    Bulan24 = pcv.Bulan24,
                    Tahun3 = pcv.Tahun3,
                    Tahun5 = pcv.Tahun5,
                    Tahun6 = pcv.Tahun6,
                    Tahun7 = pcv.Tahun7,
                    Tahun8 = pcv.Tahun8,
                    Tahun9 = pcv.Tahun9,
                    Tahun10 = pcv.Tahun10,
                    Tahun12 = pcv.Tahun12,
                    Tahun18 = pcv.Tahun18
                };

                return pcvToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        public async Task UpdateImunisasiPcvAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var pcv = await _context.ImunisasiPCVs
                    .Where(x => x.ImunisasiAnak.ImunisasiAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                pcv.Lahir = dto.Lahir;
                pcv.Bulan1 = dto.Bulan1;
                pcv.Bulan2 = dto.Bulan2;
                pcv.Bulan3 = dto.Bulan3;
                pcv.Bulan4 = dto.Bulan4;
                pcv.Bulan5 = dto.Bulan5;
                pcv.Bulan6 = dto.Bulan6;
                pcv.Bulan9 = dto.Bulan9;
                pcv.Bulan12 = dto.Bulan12;
                pcv.Bulan15 = dto.Bulan15;
                pcv.Bulan18 = dto.Bulan18;
                pcv.Bulan24 = dto.Bulan24;
                pcv.Tahun3 = dto.Tahun3;
                pcv.Tahun5 = dto.Tahun5;
                pcv.Tahun6 = dto.Tahun6;
                pcv.Tahun7 = dto.Tahun7;
                pcv.Tahun8 = dto.Tahun8;
                pcv.Tahun9 = dto.Tahun9;
                pcv.Tahun10 = dto.Tahun10;
                pcv.Tahun12 = dto.Tahun12;
                pcv.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}