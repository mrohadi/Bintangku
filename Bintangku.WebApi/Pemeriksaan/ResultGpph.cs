using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultGpph
    {
        public string Interpretasi { get; set; } = "";
        public string Intervensi { get; set; } = "";
        public byte Point { get; set; } = 0;
        private readonly PemeriksaanGpphDto _pemeriksaanGpphDto;
        public ResultGpph(PemeriksaanGpphDto pemeriksaanGpphDto) 
        {
            _pemeriksaanGpphDto = pemeriksaanGpphDto;
            
            CalculatePoint();

            Result();
        }

        public void CalculatePoint() 
        {
            Point = (byte)(
                _pemeriksaanGpphDto.Question1 + _pemeriksaanGpphDto.Question2
                + _pemeriksaanGpphDto.Question3 + _pemeriksaanGpphDto.Question4
                + _pemeriksaanGpphDto.Question5 + _pemeriksaanGpphDto.Question6
                + _pemeriksaanGpphDto.Question7 + _pemeriksaanGpphDto.Question8
                + _pemeriksaanGpphDto.Question9 + _pemeriksaanGpphDto.Question10);
        }

        public void Result() 
        {
            if(Point >= 13)
            {
                Interpretasi = "GPPH";
                Intervensi = "Rujuk Kerumah Sakit";
            }
            else
            {
                Interpretasi = "Normal";
                Intervensi = "Tidak Perlu Rujuk Kerumah Sakit";
            }
        }
    }
}