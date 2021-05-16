using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository.Imunisasi
{
    public class ImunisasiHepatitisBRepository : IImunisasiHepatitisBRepository
    {
        private readonly ApplicationDataContext _context;
        public ImunisasiHepatitisBRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<ImunisasiDto> GetImunisasiHepatitisBAsync(int dataAnakId)
        {
            var imunisasi = await _context.ImunisasiHepatitisBs 
                .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                .SingleOrDefaultAsync();
            
            var imunisasiToReturn = new ImunisasiDto()
            {
                Lahir = imunisasi.Lahir,
                Bulan1 = imunisasi.Bulan1,
                Bulan2 = imunisasi.Bulan2,
                Bulan3 = imunisasi.Bulan3,
                Bulan4 = imunisasi.Bulan4,
                Bulan5 = imunisasi.Bulan5,
                Bulan6 = imunisasi.Bulan6,
                Bulan9 = imunisasi.Bulan9,
                Bulan12 = imunisasi.Bulan12,
                Bulan15 = imunisasi.Bulan15,
                Bulan18 = imunisasi.Bulan18,
                Bulan24 = imunisasi.Bulan24,
                Tahun3 = imunisasi.Tahun3,
                Tahun5 = imunisasi.Tahun5,
                Tahun6 = imunisasi.Tahun6,
                Tahun7 = imunisasi.Tahun7,
                Tahun8 = imunisasi.Tahun8,
                Tahun9 = imunisasi.Tahun9,
                Tahun10 = imunisasi.Tahun10,
                Tahun12 = imunisasi.Tahun12,
                Tahun18 = imunisasi.Tahun18
            };

            return imunisasiToReturn;
        }

        public async Task UpdateImunisasiHepatitisBAsyn(int dataAnakId, ImunisasiDto dto)
        {
            var imunisasi = await _context.ImunisasiHepatitisBs
                .Where(x => x.ImunisasiAnak.DataAnakId == dataAnakId)
                .SingleOrDefaultAsync();

            imunisasi.Lahir = dto.Lahir;
            imunisasi.Bulan1 = dto.Bulan1;
            imunisasi.Bulan2 = dto.Bulan2;
            imunisasi.Bulan3 = dto.Bulan3;
            imunisasi.Bulan4 = dto.Bulan4;
            imunisasi.Bulan5 = dto.Bulan5;
            imunisasi.Bulan6 = dto.Bulan6;
            imunisasi.Bulan9 = dto.Bulan9;
            imunisasi.Bulan12 = dto.Bulan12;
            imunisasi.Bulan15 = dto.Bulan15;
            imunisasi.Bulan18 = dto.Bulan18;
            imunisasi.Bulan24 = dto.Bulan24;
            imunisasi.Tahun3 = dto.Tahun3;
            imunisasi.Tahun5 = dto.Tahun5;
            imunisasi.Tahun6 = dto.Tahun6;
            imunisasi.Tahun7 = dto.Tahun7;
            imunisasi.Tahun8 = dto.Tahun8;
            imunisasi.Tahun9 = dto.Tahun9;
            imunisasi.Tahun10 = dto.Tahun10;
            imunisasi.Tahun12 = dto.Tahun12;
            imunisasi.Tahun18 = dto.Tahun18;
        }
    }
}