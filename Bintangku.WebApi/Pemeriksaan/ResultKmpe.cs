using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultKmpe
    {
        public string Interpretasi { get; set; } = "";
        public string Intervensi { get; set; } = "";
        public byte JumlahYa { get; set; } = 0;
        private readonly PemeriksaanKmpeDto _pemeriksaanKmpeDto;
        public ResultKmpe(PemeriksaanKmpeDto pemeriksaanKmpeDto)
        {
            _pemeriksaanKmpeDto = pemeriksaanKmpeDto;

            TotalAnswer();
            
            Result();
        }
        
        public void TotalAnswer()
        {
            if(_pemeriksaanKmpeDto.Question1 == true)
               JumlahYa++;
            if(_pemeriksaanKmpeDto.Question2 == true) 
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question3 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question4 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question5 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question6 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question7 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question8 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question9 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question10 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question11 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question12 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question13 == true)
                JumlahYa++;
            if(_pemeriksaanKmpeDto.Question14 == true)
                JumlahYa++;
        }
        
        public void Result()
        {
            if(JumlahYa == 1)
            {
                Interpretasi = "Kemungkinan Anak Mengalami Masalah Emosional";
                Intervensi = "Lakukan konseling kepada orang tua menggunakan buku Pola Asuh Yang Mendukung Perkembangan Anak";
            }
            else if(JumlahYa > 1)
            {
                Interpretasi = "Anak Mengalami Masalah Emosional";
                Intervensi = "Rujuk Anak Kerumah Sakit";
            }
            else
            {
                Interpretasi = "Anak Normal";
                Intervensi = "Tidak Perlu Rujuk";
            }
        }
    }
}