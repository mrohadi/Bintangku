using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultStatusGiziBbTb
    {
        public string StatusGizi { get; set; } = "";
        public string Tindakan { get; set; } = "";
        private readonly PemeriksaanStatusGiziBbTbDto _giziBbTbDto;
        public ResultStatusGiziBbTb(PemeriksaanStatusGiziBbTbDto giziBbTbDto)
        {
            _giziBbTbDto = giziBbTbDto;
            
            Result();
        }

        /// <summary>
        /// Determine hasil pemeriksaan 
        /// </summary>
        public void Result()
        {
            if(_giziBbTbDto.ZCode > 2)
            {
                StatusGizi = "Gemuk";
                Tindakan = "Konseling Gizi Sesuai Penyebab";
            }
            if(_giziBbTbDto.ZCode >= -2 && _giziBbTbDto.ZCode <= 2)
            {
                StatusGizi = "Normal";
                Tindakan = "Berikan Pujian Kepada Ibu dan Anak";
            }
            if(_giziBbTbDto.ZCode >= -3 && _giziBbTbDto.ZCode <= -2)
            {
                StatusGizi = "Kurus";
                Tindakan = "Konseling Gizi Sesuai Penyebab";
            }
            if(_giziBbTbDto.ZCode < -3)
            {
                StatusGizi = "Sangat Kurus";
                Tindakan = "Segera Rujuk ke PKM dengan TFC atau ke RS";
            }
        }
    }
}