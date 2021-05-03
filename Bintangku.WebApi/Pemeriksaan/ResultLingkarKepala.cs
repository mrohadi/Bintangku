using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultLingkarKepala
    {
        public string Klasifikasi { get; set; } = "";
        public string Tindakan { get; set; } = "";
        private PemeriksaanLingkarKepalaDto _dto;
        public ResultLingkarKepala(PemeriksaanLingkarKepalaDto dto)
        {
            _dto = dto;

            Result();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Result()
        {
            if(_dto.Kurva > 2)
            {
                Klasifikasi = "Makrisefali";
                Tindakan = "Rujuk ke Rumah Sakit";
            }
            if(_dto.Kurva >= -2 && _dto.Kurva <= 2)
            {
                Klasifikasi = "Normal";
                Tindakan = "Beri Pujian kepada Ibu dan Anak";
            }
            if(_dto.Kurva < -2)
            {
                Klasifikasi = "Makrosefali";
                Tindakan = "Rujuk ke Rumah Sakit";
            }
        }
    }
}