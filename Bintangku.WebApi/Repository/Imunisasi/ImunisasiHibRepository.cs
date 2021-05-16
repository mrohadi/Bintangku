using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiHibRepository : IImunisasiHibRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiHibRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiHibAsync(int dataAnakId)
        {
            try
            {
                var hib = await _context.ImunisasiHibs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var hibToReturn = new ImunisasiDto
                {
                    Lahir = hib.Lahir,
                    Bulan1 = hib.Bulan1,
                    Bulan2 = hib.Bulan2,
                    Bulan3 = hib.Bulan3,
                    Bulan4 = hib.Bulan4,
                    Bulan5 = hib.Bulan5,
                    Bulan6 = hib.Bulan6,
                    Bulan9 = hib.Bulan9,
                    Bulan12 = hib.Bulan12,
                    Bulan15 = hib.Bulan15,
                    Bulan18 = hib.Bulan18,
                    Bulan24 = hib.Bulan24,
                    Tahun3 = hib.Tahun3,
                    Tahun5 = hib.Tahun5,
                    Tahun6 = hib.Tahun6,
                    Tahun7 = hib.Tahun7,
                    Tahun8 = hib.Tahun8,
                    Tahun9 = hib.Tahun9,
                    Tahun10 = hib.Tahun10,
                    Tahun12 = hib.Tahun12,
                    Tahun18 = hib.Tahun18
                };
                return hibToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiHibAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var hib = await _context.ImunisasiHibs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();

                hib.Lahir = dto.Lahir;
                hib.Bulan1 = dto.Bulan1;
                hib.Bulan2 = dto.Bulan2;
                hib.Bulan3 = dto.Bulan3;
                hib.Bulan4 = dto.Bulan4;
                hib.Bulan5 = dto.Bulan5;
                hib.Bulan6 = dto.Bulan6;
                hib.Bulan9 = dto.Bulan9;
                hib.Bulan12 = dto.Bulan12;
                hib.Bulan15 = dto.Bulan15;
                hib.Bulan18 = dto.Bulan18;
                hib.Bulan24 = dto.Bulan24;
                hib.Tahun3 = dto.Tahun3;
                hib.Tahun5 = dto.Tahun5;
                hib.Tahun6 = dto.Tahun6;
                hib.Tahun7 = dto.Tahun7;
                hib.Tahun8 = dto.Tahun8;
                hib.Tahun9 = dto.Tahun9;
                hib.Tahun10 = dto.Tahun10;
                hib.Tahun12 = dto.Tahun12;
                hib.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}