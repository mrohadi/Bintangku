using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiBcgRepository : IImunisasiBcgRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiBcgRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<ImunisasiDto> GetImunisasiBcgAsync(int dataAnakId)
        {
            try
            {
                var bcg = await _context.ImunisasiBCGs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var bcgToReturn = new ImunisasiDto
                {
                    Lahir = bcg.Lahir,
                    Bulan1 = bcg.Bulan1,
                    Bulan2 = bcg.Bulan2,
                    Bulan3 = bcg.Bulan3,
                    Bulan4 = bcg.Bulan4,
                    Bulan5 = bcg.Bulan5,
                    Bulan6 = bcg.Bulan6,
                    Bulan9 = bcg.Bulan9,
                    Bulan12 = bcg.Bulan12,
                    Bulan15 = bcg.Bulan12,
                    Bulan18 = bcg.Bulan18,
                    Bulan24 = bcg.Bulan24,
                    Tahun3 = bcg.Tahun3,
                    Tahun5 = bcg.Tahun5,
                    Tahun6 = bcg.Tahun6,
                    Tahun7 = bcg.Tahun7,
                    Tahun8 = bcg.Tahun8,
                    Tahun9 = bcg.Tahun9,
                    Tahun10 = bcg.Tahun10,
                    Tahun12 = bcg.Tahun12,
                    Tahun18 = bcg.Tahun18
                };
                return bcgToReturn;    
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiBcgAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var bcg = await _context.ImunisasiBCGs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                bcg.Lahir = dto.Lahir;
                bcg.Bulan1 = dto.Bulan1;
                bcg.Bulan2 = dto.Bulan2;
                bcg.Bulan3 = dto.Bulan3;
                bcg.Bulan4 = dto.Bulan4;
                bcg.Bulan5 = dto.Bulan5;
                bcg.Bulan6 = dto.Bulan6;
                bcg.Bulan9 = dto.Bulan9;
                bcg.Bulan12 = dto.Bulan12;
                bcg.Bulan15 = dto.Bulan15;
                bcg.Bulan18 = dto.Bulan18;
                bcg.Bulan24 = dto.Bulan24;
                bcg.Tahun3 = dto.Tahun3;
                bcg.Tahun5 = dto.Tahun5;
                bcg.Tahun6 = dto.Tahun6;
                bcg.Tahun7 = dto.Tahun7;
                bcg.Tahun8 = dto.Tahun8;
                bcg.Tahun9 = dto.Tahun9;
                bcg.Tahun10 = dto.Tahun10;
                bcg.Tahun12 = dto.Tahun12;
                bcg.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}