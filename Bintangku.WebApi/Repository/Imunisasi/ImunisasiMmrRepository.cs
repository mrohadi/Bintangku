using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiMmrRepository : IImunisasiMmrRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiMmrRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiMmrAsync(int dataAnakId)
        {
            try
            {
                var mmr = await _context.ImunisasiCampaks
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var mmrToReturn = new ImunisasiDto
                {
                    Lahir = mmr.Lahir,
                    Bulan1 = mmr.Bulan1,
                    Bulan2 = mmr.Bulan2,
                    Bulan3 = mmr.Bulan3,
                    Bulan4 = mmr.Bulan4,
                    Bulan5 = mmr.Bulan5,
                    Bulan6 = mmr.Bulan6,
                    Bulan9 = mmr.Bulan9,
                    Bulan12 = mmr.Bulan12,
                    Bulan15 = mmr.Bulan15,
                    Bulan18 = mmr.Bulan18,
                    Bulan24 = mmr.Bulan24,
                    Tahun3 = mmr.Tahun3,
                    Tahun5 = mmr.Tahun5,
                    Tahun6 = mmr.Tahun6,
                    Tahun7 = mmr.Tahun7,
                    Tahun8 = mmr.Tahun8,
                    Tahun9 = mmr.Tahun9,
                    Tahun10 = mmr.Tahun10,
                    Tahun12 = mmr.Tahun12,
                    Tahun18 = mmr.Tahun18
                };

                return mmrToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiMmrAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var mmr = await _context.ImunisasiMMRs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                mmr.Lahir = dto.Lahir;
                mmr.Bulan1 = dto.Bulan1;
                mmr.Bulan2 = dto.Bulan2;
                mmr.Bulan3 = dto.Bulan3;
                mmr.Bulan4 = dto.Bulan4;
                mmr.Bulan5 = dto.Bulan5;
                mmr.Bulan6 = dto.Bulan6;
                mmr.Bulan9 = dto.Bulan9;
                mmr.Bulan12 = dto.Bulan12;
                mmr.Bulan15 = dto.Bulan15;
                mmr.Bulan18 = dto.Bulan18;
                mmr.Bulan24 = dto.Bulan24;
                mmr.Tahun3 = dto.Tahun3;
                mmr.Tahun5 = dto.Tahun5;
                mmr.Tahun6 = dto.Tahun6;
                mmr.Tahun7 = dto.Tahun7;
                mmr.Tahun8 = dto.Tahun8;
                mmr.Tahun9 = dto.Tahun9;
                mmr.Tahun10 = dto.Tahun10;
                mmr.Tahun12 = dto.Tahun12;
                mmr.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}