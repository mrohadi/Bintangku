using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiHepatitisARepository : IImunisasiHepatitisARepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiHepatitisARepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<ImunisasiDto> GetImunisasiHepatitisAAsync(int dataAnakId)
        {
            try
            {
                var hepatitisA = await _context.ImunisasiHepatitisAs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var hepatitisAToReturn = new ImunisasiDto
                {
                    Lahir = hepatitisA.Lahir,
                    Bulan1 = hepatitisA.Bulan1,
                    Bulan2 = hepatitisA.Bulan2,
                    Bulan3 = hepatitisA.Bulan3,
                    Bulan4 = hepatitisA.Bulan4,
                    Bulan5 = hepatitisA.Bulan5,
                    Bulan6 = hepatitisA.Bulan6,
                    Bulan9 = hepatitisA.Bulan9,
                    Bulan12 = hepatitisA.Bulan12,
                    Bulan15 = hepatitisA.Bulan15,
                    Bulan18 = hepatitisA.Bulan18,
                    Bulan24 = hepatitisA.Bulan24,
                    Tahun3 = hepatitisA.Tahun3,
                    Tahun5 = hepatitisA.Tahun5,
                    Tahun6 = hepatitisA.Tahun6,
                    Tahun7 = hepatitisA.Tahun7,
                    Tahun8 = hepatitisA.Tahun8,
                    Tahun9 = hepatitisA.Tahun9,
                    Tahun10 = hepatitisA.Tahun10,
                    Tahun12 = hepatitisA.Tahun12,
                    Tahun18 = hepatitisA.Tahun18
                };

                return hepatitisAToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiHepatitisAAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var hepatitisA = await _context.ImunisasiHepatitisAs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)               
                    .SingleOrDefaultAsync();
                
                hepatitisA.Lahir = dto.Lahir;
                hepatitisA.Bulan1 = dto.Bulan1;
                hepatitisA.Bulan2 = dto.Bulan2;
                hepatitisA.Bulan3 = dto.Bulan3;
                hepatitisA.Bulan4 = dto.Bulan4;
                hepatitisA.Bulan5 = dto.Bulan5;
                hepatitisA.Bulan6 = dto.Bulan6;
                hepatitisA.Bulan9 = dto.Bulan9;
                hepatitisA.Bulan12 = dto.Bulan12;
                hepatitisA.Bulan15 = dto.Bulan15;
                hepatitisA.Bulan18 = dto.Bulan18;
                hepatitisA.Bulan24 = dto.Bulan24;
                hepatitisA.Tahun3 = dto.Tahun3;
                hepatitisA.Tahun5 = dto.Tahun5;
                hepatitisA.Tahun6 = dto.Tahun6;
                hepatitisA.Tahun7 = dto.Tahun7;
                hepatitisA.Tahun8 = dto.Tahun8;
                hepatitisA.Tahun9 = dto.Tahun9;
                hepatitisA.Tahun10 = dto.Tahun10;
                hepatitisA.Tahun12 = dto.Tahun12;
                hepatitisA.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}