using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiJapaneseEncephalitisRepository : IImunisasiJapaneseEncephalitisRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiJapaneseEncephalitisRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiJapaneseEncephalitisAsync(int dataAnakId)
        {
            try
            {
                var je = await _context.ImunisasiJapaneseEncephalitis
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var jeToReturn = new ImunisasiDto
                {
                    Lahir = je.Lahir,
                    Bulan1 = je.Bulan1,
                    Bulan2 = je.Bulan2,
                    Bulan3 = je.Bulan3,
                    Bulan4 = je.Bulan4,
                    Bulan5 = je.Bulan5,
                    Bulan6 = je.Bulan6,
                    Bulan9 = je.Bulan9,
                    Bulan12 = je.Bulan12,
                    Bulan15 = je.Bulan15,
                    Bulan18 = je.Bulan18,
                    Bulan24 = je.Bulan24,
                    Tahun3 = je.Tahun3,
                    Tahun5 = je.Tahun5,
                    Tahun6 = je.Tahun6,
                    Tahun7 = je.Tahun7,
                    Tahun8 = je.Tahun8,
                    Tahun9 = je.Tahun9,
                    Tahun10 = je.Tahun10,
                    Tahun12 = je.Tahun12,
                    Tahun18 = je.Tahun18
                };

                return jeToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiJapaneseEncephalitisAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var je = await _context.ImunisasiJapaneseEncephalitis
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                je.Lahir = dto.Lahir;
                je.Bulan1 = dto.Bulan1;
                je.Bulan2 = dto.Bulan2;
                je.Bulan3 = dto.Bulan3;
                je.Bulan4 = dto.Bulan4;
                je.Bulan5 = dto.Bulan5;
                je.Bulan6 = dto.Bulan6;
                je.Bulan9 = dto.Bulan9;
                je.Bulan12 = dto.Bulan12;
                je.Bulan15 = dto.Bulan15;
                je.Bulan18 = dto.Bulan18;
                je.Bulan24 = dto.Bulan24;
                je.Tahun3 = dto.Tahun3;
                je.Tahun5 = dto.Tahun5;
                je.Tahun6 = dto.Tahun6;
                je.Tahun7 = dto.Tahun7;
                je.Tahun8 = dto.Tahun8;
                je.Tahun9 = dto.Tahun9;
                je.Tahun10 = dto.Tahun10;
                je.Tahun12 = dto.Tahun12;
                je.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}