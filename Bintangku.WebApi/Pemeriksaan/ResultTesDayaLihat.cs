using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultTesDayaLihat
    {
        public string Interpretasi { get; set; } = "";
        public string Intervensi { get; set; } = "";
        private PemeriksaanDayaLihatDto _pemeriksaanDayaLihatDto; 

        public ResultTesDayaLihat(PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto)
        {
            _pemeriksaanDayaLihatDto = pemeriksaanDayaLihatDto;
            
            Result();
        }
        
        private void Result()
        {
            if( _pemeriksaanDayaLihatDto.MataKanan <= 3 && _pemeriksaanDayaLihatDto.MataKiri <=3)
            {
                Interpretasi = "Normal";
                Intervensi = "None";
            }
            else
            {
                Interpretasi = "Mengalami Masalah Daya Lihat";
                Intervensi = "Minta Anak Untuk Datang Pemeriksaan Berikutnya";
            }
        }
    }
}