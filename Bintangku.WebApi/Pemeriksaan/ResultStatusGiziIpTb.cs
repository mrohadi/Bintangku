using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultStatusGiziIpTb
    {
        public string StatusGizi { get; set; } = "";
        public string Tindakan { get; set; } = "";
        private PemeriksaanStatusGiziIpTbDto _dto;
        public ResultStatusGiziIpTb(PemeriksaanStatusGiziIpTbDto dto)
        {
            _dto = dto;
            
            Result();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Result()
        {
            try
            {
                if(_dto.ZCode > 2)
                {
                    StatusGizi = "Tinggi";
                    Tindakan = "Jadwalkan kunjungan berikutnya";
                }
                if(_dto.ZCode >= -2 && _dto.ZCode <= 2)
                {
                    StatusGizi = "Normal";
                    Tindakan = "Jadwalkan kunjungan berikutnya";
                }
                if(_dto.ZCode >= -3 && _dto.ZCode < -2)
                {
                    StatusGizi = "Pendek";
                    Tindakan = "Asupan gizi ditingkatkan dan jadwlkan kunjungan berikutnya";
                }
                if(_dto.ZCode < -3)
                {
                    StatusGizi = "Sangat pendek";
                    Tindakan = "Segera rujuk ke fasilitas layanan kesehatan";
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}