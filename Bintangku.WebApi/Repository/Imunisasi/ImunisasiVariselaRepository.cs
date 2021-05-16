using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiVariselaRepository : IImunisasiVariselaRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiVariselaRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiVariselaAsync(int dataAnakId)
        {
            try
            {
                var varisela = await _context.ImunisasiVariselas
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var variselaToReturn = new ImunisasiDto 
                {
                    Lahir = varisela.Lahir,
                    Bulan1 = varisela.Bulan1,
                    Bulan2 = varisela.Bulan2,
                    Bulan3 = varisela.Bulan3,
                    Bulan4 = varisela.Bulan4,
                    Bulan5 = varisela.Bulan5,
                    Bulan6 = varisela.Bulan6,
                    Bulan9 = varisela.Bulan9,
                    Bulan12 = varisela.Bulan12,
                    Bulan15 = varisela.Bulan15,
                    Bulan18 = varisela.Bulan18,
                    Bulan24 = varisela.Bulan24,
                    Tahun3 = varisela.Tahun3,
                    Tahun5 = varisela.Tahun5,
                    Tahun6 = varisela.Tahun6,
                    Tahun7 = varisela.Tahun7,
                    Tahun8 = varisela.Tahun8,
                    Tahun9 = varisela.Tahun9,
                    Tahun10 = varisela.Tahun10,
                    Tahun12 = varisela.Tahun12,
                    Tahun18 = varisela.Tahun18
                };

                return variselaToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiVariselaAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var varisela = await _context.ImunisasiVariselas
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();

                varisela.Lahir = dto.Lahir;
                varisela.Bulan1 = dto.Bulan1;
                varisela.Bulan2 = dto.Bulan2;
                varisela.Bulan3 = dto.Bulan3;
                varisela.Bulan4 = dto.Bulan4;
                varisela.Bulan5 = dto.Bulan5;
                varisela.Bulan6 = dto.Bulan6;
                varisela.Bulan9 = dto.Bulan9;
                varisela.Bulan12 = dto.Bulan12;
                varisela.Bulan15 = dto.Bulan15;
                varisela.Bulan18 = dto.Bulan18;
                varisela.Bulan24 = dto.Bulan24;
                varisela.Tahun3 = dto.Tahun3;
                varisela.Tahun5 = dto.Tahun5;
                varisela.Tahun6 = dto.Tahun6;
                varisela.Tahun7 = dto.Tahun7;
                varisela.Tahun8 = dto.Tahun8;
                varisela.Tahun9 = dto.Tahun9;
                varisela.Tahun10 = dto.Tahun10;
                varisela.Tahun12 = dto.Tahun12;
                varisela.Tahun18 = dto.Tahun18;            
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}