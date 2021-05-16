using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiInfluenzaRepository : IImunisasiInfluenzaRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiInfluenzaRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiInfluenzaAsync(int dataAnakId)
        {
            try
            {
                var influenza = await _context.ImunisasiInfluenzas
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var influenzaToReturn = new ImunisasiDto
                {
                    Lahir = influenza.Lahir,
                    Bulan1 = influenza.Bulan1,
                    Bulan2 = influenza.Bulan2,
                    Bulan3 = influenza.Bulan3,
                    Bulan4 = influenza.Bulan4,
                    Bulan5 = influenza.Bulan5,
                    Bulan6 = influenza.Bulan6,
                    Bulan9 = influenza.Bulan9,
                    Bulan12 = influenza.Bulan12,
                    Bulan15 = influenza.Bulan15,
                    Bulan18 = influenza.Bulan18,
                    Bulan24 = influenza.Bulan24,
                    Tahun3 = influenza.Tahun3,
                    Tahun5 = influenza.Tahun5,
                    Tahun6 = influenza.Tahun6,
                    Tahun7 = influenza.Tahun7,
                    Tahun8 = influenza.Tahun8,
                    Tahun9 = influenza.Tahun9,
                    Tahun10 = influenza.Tahun10,
                    Tahun12 = influenza.Tahun12,
                    Tahun18 = influenza.Tahun18
                };

                return influenzaToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiInfluenzaAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var influenza = await _context.ImunisasiInfluenzas
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                    influenza.Lahir = dto.Lahir;
                    influenza.Bulan1 = dto.Bulan1;
                    influenza.Bulan2 = dto.Bulan2;
                    influenza.Bulan3 = dto.Bulan3;
                    influenza.Bulan4 = dto.Bulan4;
                    influenza.Bulan5 = dto.Bulan5;
                    influenza.Bulan6 = dto.Bulan6;
                    influenza.Bulan9 = dto.Bulan9;
                    influenza.Bulan12 = dto.Bulan12;
                    influenza.Bulan15 = dto.Bulan15;
                    influenza.Bulan18 = dto.Bulan18;
                    influenza.Bulan24 = dto.Bulan24;
                    influenza.Tahun3 = dto.Tahun3;
                    influenza.Tahun5 = dto.Tahun5;
                    influenza.Tahun6 = dto.Tahun6;
                    influenza.Tahun7 = dto.Tahun7;
                    influenza.Tahun8 = dto.Tahun8;
                    influenza.Tahun9 = dto.Tahun9;
                    influenza.Tahun10 = dto.Tahun10;
                    influenza.Tahun12 = dto.Tahun12;
                    influenza.Tahun18 = dto.Tahun18;               
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}