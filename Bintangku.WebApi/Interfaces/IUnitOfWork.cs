using System.Threading.Tasks;
using Bintangku.WebApi.Interfaces.Imunisasi;
using Bintangku.WebApi.Interfaces.Pemeriksaan;

namespace Bintangku.WebApi.Interfaces
{
    public interface IUnitOfWork
    {
        INakesUserRepository NakesUserRepository { get; }
        
        IDataAnakRepository DataAnakRepository  { get; }
        IRiwayatKelahiranRepository RiwayatKelahiranRepository { get; }
        IRiwayatOrangTuaRepository RiwayatOrangTuaRepository { get; }
        IPemeriksaanDayaLihatRepository PemeriksaanDayaLihatRepository { get; }
        IPemeriksaanStatusGiziIpTbRepository PemeriksaanStatusGiziIpTbRepository { get; }
        IPemeriksaanStatusGiziImtURepository PemeriksaanStatusGiziImtURepository { get; }
        IPemeriksaanStatusGiziBbTbRepository PemeriksaanStatusGiziBbTbRepository { get; }
        IPemeriksaanMchatRepository PemeriksaanMchatRepository { get; }
        IPemeriksaanLingkarKepalaRepository PemeriksaanLingkarKepalaRepository { get; }
        IPemeriksaanKmpeRepository PemeriksaanKmpeRepository { get; }
        IPemeriksaanGpphRepository PemeriksaanGpphRepository { get; }

        IImunisasiRepository ImunisasiRepository { get; }
        IImunisasiHepatitisBRepository ImunisasiHepatitisBRepository { get; }
        IImunisasiPolioRepository ImunisasiPolioRepository { get; }
        IImunisasiBcgRepository ImunisasiBcgRepository { get; }
        IImunisasiDtpRepository ImunisasiDtpRepository { get; }
        IImunisasiHibRepository ImunisasiHibRepository { get; }
        IImunisasiPcvRepository ImunisasiPcvRepository { get; }
        IImunisasiRotavirusRepository ImunisasiRotavirusRepository { get; }
        IImunisasiInfluenzaRepository ImunisasiInfluenzaRepository { get; }
        IImunisasiCampakRepository ImunisasiCampakRepository { get; }
        IImunisasiMmrRepository ImunisasiMmrRepository { get; }
        IImunisasiTifoidRepository ImunisasiTifoidRepository { get; }
        IImunisasiHepatitisARepository ImunisasiHepatitisARepository { get; }
        IImunisasiVariselaRepository ImunisasiVariselaRepository { get; }
        IImunisasiHpvRepository ImunisasiHpvRepository { get; }
        IImunisasiJapaneseEncephalitisRepository ImunisasiJapaneseEncephalitisRepository { get; }
        IImunisasiDengueRepository ImunisasiDengueRepository { get; }

        Task<bool> Complete();
    }
}