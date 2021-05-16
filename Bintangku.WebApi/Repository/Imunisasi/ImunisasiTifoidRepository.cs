using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiTifoidRepository : IImunisasiTifoidRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiTifoidRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiTifoidAsync(int dataAnakId)
        {
            try
            {
                var tifoid = await _context.ImunisasiTifoids
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var tifoidToReturn = new ImunisasiDto
                {
                    Lahir = tifoid.Lahir,
                    Bulan1 = tifoid.Bulan1,
                    Bulan2 = tifoid.Bulan2,
                    Bulan3 = tifoid.Bulan3,
                    Bulan4 = tifoid.Bulan4,
                    Bulan5 = tifoid.Bulan5,
                    Bulan6 = tifoid.Bulan6,
                    Bulan9 = tifoid.Bulan9,
                    Bulan12 = tifoid.Bulan12,
                    Bulan15 = tifoid.Bulan15,
                    Bulan18 = tifoid.Bulan18,
                    Bulan24 = tifoid.Bulan24,
                    Tahun3 = tifoid.Tahun3,
                    Tahun5 = tifoid.Tahun5,
                    Tahun6 = tifoid.Tahun6,
                    Tahun7 = tifoid.Tahun7,
                    Tahun8 = tifoid.Tahun8,
                    Tahun9 = tifoid.Tahun9,
                    Tahun10 = tifoid.Tahun10,
                    Tahun12 = tifoid.Tahun12,
                    Tahun18 = tifoid.Tahun18
                };

                return tifoidToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiTifoidAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var tifoid = await _context.ImunisasiTifoids
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                tifoid.Lahir = dto.Lahir;
                tifoid.Bulan1 = dto.Bulan1;
                tifoid.Bulan2 = dto.Bulan2;
                tifoid.Bulan3 = dto.Bulan3;
                tifoid.Bulan4 = dto.Bulan4;
                tifoid.Bulan5 = dto.Bulan5;
                tifoid.Bulan6 = dto.Bulan6;
                tifoid.Bulan9 = dto.Bulan9;
                tifoid.Bulan12 = dto.Bulan12;
                tifoid.Bulan15 = dto.Bulan15;
                tifoid.Bulan18 = dto.Bulan18;
                tifoid.Bulan24 = dto.Bulan24;
                tifoid.Tahun3 = dto.Tahun3;
                tifoid.Tahun5 = dto.Tahun5;
                tifoid.Tahun6 = dto.Tahun6;
                tifoid.Tahun7 = dto.Tahun7;
                tifoid.Tahun8 = dto.Tahun8;
                tifoid.Tahun9 = dto.Tahun9;
                tifoid.Tahun10 = dto.Tahun10;
                tifoid.Tahun12 = dto.Tahun12;
                tifoid.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}