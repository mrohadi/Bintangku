using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiDtpRepository : IImunisasiDtpRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiDtpRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<ImunisasiDto> GetImunisasiDtpAsync(int dataAnakId)
        {
            try
            {
                var dpt = await _context.ImunisasiDTPs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                var dptToReturn = new ImunisasiDto
                {
                    Lahir = dpt.Lahir,
                    Bulan1 = dpt.Bulan1,
                    Bulan2 = dpt.Bulan2,
                    Bulan3 = dpt.Bulan3,
                    Bulan4 = dpt.Bulan4,
                    Bulan5 = dpt.Bulan5,
                    Bulan6 = dpt.Bulan6,
                    Bulan9 = dpt.Bulan9,
                    Bulan12 = dpt.Bulan12,
                    Bulan15 = dpt.Bulan15,
                    Bulan18 = dpt.Bulan18,
                    Bulan24 = dpt.Bulan24,
                    Tahun3 = dpt.Tahun3,
                    Tahun5 = dpt.Tahun5,
                    Tahun6 = dpt.Tahun6,
                    Tahun7 = dpt.Tahun7,
                    Tahun8 = dpt.Tahun8,
                    Tahun9 = dpt.Tahun9,
                    Tahun10 = dpt.Tahun10,
                    Tahun12 = dpt.Tahun12,
                    Tahun18 = dpt.Tahun18
                };
                return dptToReturn;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateImunisasiDtpAsync(int dataAnakId, ImunisasiDto dto)
        {
            try
            {
                var dtp = await _context.ImunisasiDTPs
                    .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                    .SingleOrDefaultAsync();
                
                dtp.Lahir = dto.Lahir;
                dtp.Bulan1 = dto.Bulan1;
                dtp.Bulan2 = dto.Bulan2;
                dtp.Bulan3 = dto.Bulan3;
                dtp.Bulan4 = dto.Bulan4;
                dtp.Bulan5 = dto.Bulan5;
                dtp.Bulan6 = dto.Bulan6;
                dtp.Bulan9 = dto.Bulan9;
                dtp.Bulan12 = dto.Bulan12;
                dtp.Bulan15 = dto.Bulan15;
                dtp.Bulan18 = dto.Bulan18;
                dtp.Bulan24 = dto.Bulan24;
                dtp.Tahun3 = dto.Tahun3;
                dtp.Tahun5 = dto.Tahun5;
                dtp.Tahun6 = dto.Tahun6;
                dtp.Tahun7 = dto.Tahun7;
                dtp.Tahun8 = dto.Tahun8;
                dtp.Tahun9 = dto.Tahun9;
                dtp.Tahun10 = dto.Tahun10;
                dtp.Tahun12 = dto.Tahun12;
                dtp.Tahun18 = dto.Tahun18;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}