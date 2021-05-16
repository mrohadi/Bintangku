using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiHpvRepository : IImunisasiHpvRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiHpvRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiHpvAsync(int dataAnakId)
        {
            try
            {
                var hpv = await _context.ImunisasiHPVs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();

                var hpvToReturn = new ImunisasiDto
                {
                    Lahir = hpv.Lahir,
                    Bulan1 = hpv.Bulan1,
                    Bulan2 = hpv.Bulan2,
                    Bulan3 = hpv.Bulan3,
                    Bulan4 = hpv.Bulan4,
                    Bulan5 = hpv.Bulan5,
                    Bulan6 = hpv.Bulan6,
                    Bulan9 = hpv.Bulan9,
                    Bulan12 = hpv.Bulan12,
                    Bulan15 = hpv.Bulan15,
                    Bulan18 = hpv.Bulan18,
                    Bulan24 = hpv.Bulan24,
                    Tahun3 = hpv.Tahun3,
                    Tahun5 = hpv.Tahun5,
                    Tahun6 = hpv.Tahun6,
                    Tahun7 = hpv.Tahun7,
                    Tahun8 = hpv.Tahun8,
                    Tahun9 = hpv.Tahun9,
                    Tahun10 = hpv.Tahun10,
                    Tahun12 = hpv.Tahun12,
                    Tahun18 = hpv.Tahun18
                };
                return hpvToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiHpvAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var hpv = await _context.ImunisasiHPVs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                hpv.Lahir = dto.Lahir;
                hpv.Bulan1 = dto.Bulan1;
                hpv.Bulan2 = dto.Bulan2;
                hpv.Bulan3 = dto.Bulan3;
                hpv.Bulan4 = dto.Bulan4;
                hpv.Bulan5 = dto.Bulan5;
                hpv.Bulan6 = dto.Bulan6;
                hpv.Bulan9 = dto.Bulan9;
                hpv.Bulan12 = dto.Bulan12;
                hpv.Bulan15 = dto.Bulan15;
                hpv.Bulan18 = dto.Bulan18;
                hpv.Bulan24 = dto.Bulan24;
                hpv.Tahun3 = dto.Tahun3;
                hpv.Tahun5 = dto.Tahun5;
                hpv.Tahun6 = dto.Tahun6;
                hpv.Tahun7 = dto.Tahun7;
                hpv.Tahun8 = dto.Tahun8;
                hpv.Tahun9 = dto.Tahun9;
                hpv.Tahun10 = dto.Tahun10;
                hpv.Tahun12 = dto.Tahun12;
                hpv.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}