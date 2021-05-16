using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiCampakRepository : IImunisasiCampakRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiCampakRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiCampakAsync(int dataAnakId)
        {
            try
            {
                var campak = await _context.ImunisasiCampaks
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var campakToReturn = new ImunisasiDto
                {
                    Lahir = campak.Lahir,
                    Bulan1 = campak.Bulan1,
                    Bulan2 = campak.Bulan2,
                    Bulan3 = campak.Bulan3,
                    Bulan4 = campak.Bulan4,
                    Bulan5 = campak.Bulan5,
                    Bulan6 = campak.Bulan6,
                    Bulan9 = campak.Bulan9,
                    Bulan12 = campak.Bulan12,
                    Bulan15 = campak.Bulan15,
                    Bulan18 = campak.Bulan18,
                    Bulan24 = campak.Bulan24,
                    Tahun3 = campak.Tahun3,
                    Tahun5 = campak.Tahun5,
                    Tahun6 = campak.Tahun6,
                    Tahun7 = campak.Tahun7,
                    Tahun8 = campak.Tahun8,
                    Tahun9 = campak.Tahun9,
                    Tahun10 = campak.Tahun10,
                    Tahun12 = campak.Tahun12,
                    Tahun18 = campak.Tahun18
                };

                return campakToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiCampakAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var campak = await _context.ImunisasiCampaks
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                    campak.Lahir = dto.Lahir;
                    campak.Bulan1 = dto.Bulan1;
                    campak.Bulan2 = dto.Bulan2;
                    campak.Bulan3 = dto.Bulan3;
                    campak.Bulan4 = dto.Bulan4;
                    campak.Bulan5 = dto.Bulan5;
                    campak.Bulan6 = dto.Bulan6;
                    campak.Bulan9 = dto.Bulan9;
                    campak.Bulan12 = dto.Bulan12;
                    campak.Bulan15 = dto.Bulan15;
                    campak.Bulan18 = dto.Bulan18;
                    campak.Bulan24 = dto.Bulan24;
                    campak.Tahun3 = dto.Tahun3;
                    campak.Tahun5 = dto.Tahun5;
                    campak.Tahun6 = dto.Tahun6;
                    campak.Tahun7 = dto.Tahun7;
                    campak.Tahun8 = dto.Tahun8;
                    campak.Tahun9 = dto.Tahun9;
                    campak.Tahun10 = dto.Tahun10;
                    campak.Tahun12 = dto.Tahun12;
                    campak.Tahun18 = dto.Tahun18;               
            }
            catch (System.Exception)
            {
                
                throw;
            }           
        }
    }
}