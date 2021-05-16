using System.Threading.Tasks;
using AutoMapper;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Bintangku.WebApi.Interfaces.Pemeriksaan;
using Bintangku.WebApi.Repository.Imunisasi;
using Bintangku.WebApi.Repository.Pemeriksaan;

namespace Bintangku.WebApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(ApplicationDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IImunisasiRepository ImunisasiRepository => new ImunisasiRepository(_context);
        public IImunisasiHepatitisBRepository ImunisasiHepatitisBRepository => new ImunisasiHepatitisBRepository(_context);
        public IDataAnakRepository DataAnakRepository => new DataAnakRepository(_context);
        public IRiwayatOrangTuaRepository RiwayatOrangTuaRepository => new RiwayatOrangTuaRepository(_context);
        public IRiwayatKelahiranRepository RiwayatKelahiranRepository => new RiwayatKelahiranRepository(_context);
        public IPemeriksaanDayaLihatRepository PemeriksaanDayaLihatRepository => new PemeriksaanDayaLihatRepository(_context);
        public IPemeriksaanStatusGiziIpTbRepository PemeriksaanStatusGiziIpTbRepository => new PemeriksaanStatusGiziIpTbRepository(_context);
        public IPemeriksaanStatusGiziImtURepository PemeriksaanStatusGiziImtURepository => new PemeriksaanStatusGiziImtURepository(_context);
        public IPemeriksaanStatusGiziBbTbRepository PemeriksaanStatusGiziBbTbRepository => new PemeriksaanStatusGiziBbTbRepository(_context);
        public IPemeriksaanMchatRepository PemeriksaanMchatRepository => new PemeriksaanMchatRepository(_context);
        public IPemeriksaanLingkarKepalaRepository PemeriksaanLingkarKepalaRepository => new PemeriksaanLingkarKepalaRepository(_context);
        public IPemeriksaanKmpeRepository PemeriksaanKmpeRepository => new PemeriksaanKmpeRepository(_context);
        public IPemeriksaanGpphRepository PemeriksaanGpphRepository => new PemeriksaanGpphRepository(_context);
        public INakesUserRepository NakesUserRepository => new NakesUserRepository(_context, _mapper);
        public IImunisasiPolioRepository ImunisasiPolioRepository => new ImunisasiPolioRepository(_context);
        public IImunisasiBcgRepository ImunisasiBcgRepository => new ImunisasiBcgRepository(_context);
        public IImunisasiDtpRepository ImunisasiDtpRepository => new ImunisasiDtpRepository(_context);
        public IImunisasiHibRepository ImunisasiHibRepository => new ImunisasiHibRepository(_context);
        public IImunisasiPcvRepository ImunisasiPcvRepository => new ImunisasiPcvRepository(_context);
        public IImunisasiRotavirusRepository ImunisasiRotavirusRepository => new ImunisasiRotavirusRepository(_context);
        public IImunisasiInfluenzaRepository ImunisasiInfluenzaRepository => new ImunisasiInfluenzaRepository(_context);
        public IImunisasiCampakRepository ImunisasiCampakRepository => new ImunisasiCampakRepository(_context);
        public IImunisasiMmrRepository ImunisasiMmrRepository => new ImunisasiMmrRepository(_context);
        public IImunisasiTifoidRepository ImunisasiTifoidRepository => new ImunisasiTifoidRepository(_context);
        public IImunisasiHepatitisARepository ImunisasiHepatitisARepository => new ImunisasiHepatitisARepository(_context);
        public IImunisasiVariselaRepository ImunisasiVariselaRepository => new ImunisasiVariselaRepository(_context);
        public IImunisasiHpvRepository ImunisasiHpvRepository => new ImunisasiHpvRepository(_context);
        public IImunisasiJapaneseEncephalitisRepository ImunisasiJapaneseEncephalitisRepository => new ImunisasiJapaneseEncephalitisRepository(_context);
        public IImunisasiDengueRepository ImunisasiDengueRepository => new ImunisasiDengueRepository(_context);

        public async Task<bool> Complete()
        {
            if(await _context.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }
    }
}