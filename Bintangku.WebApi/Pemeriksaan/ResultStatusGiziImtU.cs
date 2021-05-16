using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultStatusGiziImtU
    {
        public int IMT { get; set; }
        public string StatusGizi { get; set; } = "";
        public string Tindakan { get; set; } = "";
        private readonly PemeriksaanStatusGiziImtUDto _dto;
        public ResultStatusGiziImtU(PemeriksaanStatusGiziImtUDto dto)
        {
            _dto = dto;
            
            Result();
        }
        
        private void Result()
        {
            IMT = _dto.BeratBadan * (_dto.TinggiBadan^2); 

            if(_dto.ZCode > 2)
            {
                StatusGizi = "Obesitas";
                Tindakan = "Segera Rujuk ke Rumah Sakit";
            }
            if(_dto.ZCode > 1 && _dto.ZCode <=2)
            {
                StatusGizi = "Gemuk";
                Tindakan = "Asupan gizi disesuaikan dengan kebutuhan dan aktivitas anak";
            }
            if(_dto.ZCode >= -2 && _dto.ZCode < 1)
            {
                StatusGizi = "Normal";
                Tindakan = "Berikan pujian kepada orang tua dan anak";
            }
            if(_dto.ZCode >= -3 && _dto.ZCode < -2)
            {
                StatusGizi = "Kurus";
                Tindakan = "Asupan gizi ditingkatkan dan jadwalkan kunjungan berikutnya";
            }
            if(_dto.ZCode < -3)
            {
                StatusGizi = "Sangat kurus";
                Tindakan = "Segera rujuk ke Puskesmas dengan TFC atau ke Rumah Sakit";
            }
        }
    }
}