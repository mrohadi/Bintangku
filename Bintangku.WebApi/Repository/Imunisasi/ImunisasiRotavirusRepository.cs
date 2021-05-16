using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiRotavirusRepository : IImunisasiRotavirusRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiRotavirusRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiRotavirusAsync(int dataAnakId)
        {
            try
            {
                var rotaVirus = await _context.ImunisasiRotaviruses
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var rotaVirusToReturn = new ImunisasiDto
                {
                    Lahir = rotaVirus.Lahir,
                    Bulan1 = rotaVirus.Bulan1,
                    Bulan2 = rotaVirus.Bulan2,
                    Bulan3 = rotaVirus.Bulan3,
                    Bulan4 = rotaVirus.Bulan4,
                    Bulan5 = rotaVirus.Bulan5,
                    Bulan6 = rotaVirus.Bulan6,
                    Bulan9 = rotaVirus.Bulan9,
                    Bulan12 = rotaVirus.Bulan12,
                    Bulan15 = rotaVirus.Bulan15,
                    Bulan18 = rotaVirus.Bulan18,
                    Bulan24 = rotaVirus.Bulan24,
                    Tahun3 = rotaVirus.Tahun3,
                    Tahun5 = rotaVirus.Tahun5,
                    Tahun6 = rotaVirus.Tahun6,
                    Tahun7 = rotaVirus.Tahun7,
                    Tahun8 = rotaVirus.Tahun8,
                    Tahun9 = rotaVirus.Tahun9,
                    Tahun10 = rotaVirus.Tahun10,
                    Tahun12 = rotaVirus.Tahun12,
                    Tahun18 = rotaVirus.Tahun18
                };

                return rotaVirusToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        public async Task UpdateImunisasiRotavirusAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var rotaVirus = await _context.ImunisasiRotaviruses
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                    rotaVirus.Lahir = dto.Lahir;
                    rotaVirus.Bulan1 = dto.Bulan1;
                    rotaVirus.Bulan2 = dto.Bulan2;
                    rotaVirus.Bulan3 = dto.Bulan3;
                    rotaVirus.Bulan4 = dto.Bulan4;
                    rotaVirus.Bulan5 = dto.Bulan5;
                    rotaVirus.Bulan6 = dto.Bulan6;
                    rotaVirus.Bulan9 = dto.Bulan9;
                    rotaVirus.Bulan12 = dto.Bulan12;
                    rotaVirus.Bulan15 = dto.Bulan15;
                    rotaVirus.Bulan18 = dto.Bulan18;
                    rotaVirus.Bulan24 = dto.Bulan24;
                    rotaVirus.Tahun3 = dto.Tahun3;
                    rotaVirus.Tahun5 = dto.Tahun5;
                    rotaVirus.Tahun6 = dto.Tahun6;
                    rotaVirus.Tahun7 = dto.Tahun7;
                    rotaVirus.Tahun8 = dto.Tahun8;
                    rotaVirus.Tahun9 = dto.Tahun9;
                    rotaVirus.Tahun10 = dto.Tahun10;
                    rotaVirus.Tahun12 = dto.Tahun12;
                    rotaVirus.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}