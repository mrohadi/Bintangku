using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiPolioRepository : IImunisasiPolioRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiPolioRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<ImunisasiDto> GetImunisasiPolioAsync(int dataAnakId)
        {
            try
            {
                var polio = await _context.ImunisasiPolios
                .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                .SingleOrDefaultAsync();

                var polioToReturn = new ImunisasiDto
                {   
                    Lahir = polio.Lahir,
                    Bulan1 = polio.Bulan1,
                    Bulan2 = polio.Bulan2,
                    Bulan3 = polio.Bulan3,
                    Bulan4 = polio.Bulan4,
                    Bulan5 = polio.Bulan5,
                    Bulan6 = polio.Bulan6,
                    Bulan9 = polio.Bulan9,
                    Bulan12 = polio.Bulan12,
                    Bulan15 = polio.Bulan15,
                    Bulan18 = polio.Bulan18,
                    Bulan24 = polio.Bulan24,
                    Tahun3 = polio.Tahun3,
                    Tahun5 = polio.Tahun5,
                    Tahun6 = polio.Tahun6,
                    Tahun7 = polio.Tahun7,
                    Tahun8 = polio.Tahun8,
                    Tahun9 = polio.Tahun9,
                    Tahun10 = polio.Tahun10,
                    Tahun12 = polio.Tahun12,
                    Tahun18 = polio.Tahun18
                };

                return polioToReturn;   
            }
            catch (System.Exception)
            {
                
                throw;
            }   
        }

        public async Task UpdateImunisasiPolioAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var polio = await _context.ImunisasiPolios
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                polio.Lahir = dto.Lahir;
                polio.Bulan1 = dto.Bulan1;
                polio.Bulan2 = dto.Bulan2;
                polio.Bulan3 = dto.Bulan3;
                polio.Bulan4 = dto.Bulan4;
                polio.Bulan5 = dto.Bulan5;
                polio.Bulan6 = dto.Bulan6;
                polio.Bulan9 = dto.Bulan9;
                polio.Bulan12 = dto.Bulan12;
                polio.Bulan15 = dto.Bulan15;
                polio.Bulan18 = dto.Bulan18;
                polio.Bulan24 = dto.Bulan24;
                polio.Tahun3 = dto.Tahun3;
                polio.Tahun5 = dto.Tahun5;
                polio.Tahun6 = dto.Tahun6;
                polio.Tahun7 = dto.Tahun7;
                polio.Tahun8 = dto.Tahun8;
                polio.Tahun9 = dto.Tahun9;
                polio.Tahun10 = dto.Tahun10;
                polio.Tahun12 = dto.Tahun12;
                polio.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                
                throw;
            } 
        }
    }
}