using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiDengueRepository : IImunisasiDengueRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiDengueRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiDengueAsync(int dataAnakId)
        {
            try
            {
                var dengue = await _context.ImunisasiDengues
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();

                var denguToReturn = new ImunisasiDto
                {
                    Lahir = dengue.Lahir,
                    Bulan1 = dengue.Bulan1,
                    Bulan2 = dengue.Bulan2,
                    Bulan3 = dengue.Bulan3,
                    Bulan4 = dengue.Bulan4,
                    Bulan5 = dengue.Bulan5,
                    Bulan6 = dengue.Bulan6,
                    Bulan9 = dengue.Bulan9,
                    Bulan12 = dengue.Bulan12,
                    Bulan15 = dengue.Bulan12,
                    Bulan18 = dengue.Bulan18,
                    Bulan24 = dengue.Bulan24,
                    Tahun3 = dengue.Tahun3,
                    Tahun5 = dengue.Tahun5,
                    Tahun6 = dengue.Tahun6,
                    Tahun7 = dengue.Tahun7,
                    Tahun8 = dengue.Tahun8,
                    Tahun9 = dengue.Tahun9,
                    Tahun10 = dengue.Tahun10,
                    Tahun12 = dengue.Tahun12,
                    Tahun18 = dengue.Tahun18
                };

                return denguToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiDengueAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var dengue = await _context.ImunisasiDengues
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                dengue.Lahir = dto.Lahir;
                dengue.Bulan1 = dto.Bulan1;
                dengue.Bulan2 = dto.Bulan2;
                dengue.Bulan3 = dto.Bulan3;
                dengue.Bulan4 = dto.Bulan4;
                dengue.Bulan5 = dto.Bulan5;
                dengue.Bulan6 = dto.Bulan6;
                dengue.Bulan9 = dto.Bulan9;
                dengue.Bulan12 = dto.Bulan12;
                dengue.Bulan15 = dto.Bulan12;
                dengue.Bulan18 = dto.Bulan18;
                dengue.Bulan24 = dto.Bulan24;
                dengue.Tahun3 = dto.Tahun3;
                dengue.Tahun5 = dto.Tahun5;
                dengue.Tahun6 = dto.Tahun6;
                dengue.Tahun7 = dto.Tahun7;
                dengue.Tahun8 = dto.Tahun8;
                dengue.Tahun9 = dto.Tahun9;
                dengue.Tahun10 = dto.Tahun10;
                dengue.Tahun12 = dto.Tahun12;
                dengue.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}