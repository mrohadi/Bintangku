using System.ComponentModel.DataAnnotations;

namespace Bintangku.WebApi.Data.Entities.Imunisasi
{
    public class ImunisasiAnak
    {
        [Key]
        public int ImunisasiAnakId { get; set; }       

        public ImunisasiHepatitisB ImunisasiHepatitisB { get; set; }
        public ImunisasiPolio ImunisasiPolio { get; set; }
        public ImunisasiBCG ImunisasiBCG { get; set; }
        public ImunisasiDTP ImunisasiDTP { get; set; }
        public ImunisasiHib ImunisasiHib { get; set; }
        public ImunisasiPCV ImunisasiPCV { get; set; }
        public ImunisasiRotavirus ImunisasiRotavirus { get; set; }
        public ImunisasiInfluenza ImunisasiInfluenza { get; set; }
        public ImunisasiCampak ImunisasiCampak { get; set; }
        public ImunisasiMMR ImunisasiMMR { get; set; }
        public ImunisasiTifoid ImunisasiTifoid { get; set; }
        public ImunisasiHepatitisA ImunisasiHepatitisA { get; set; }
        public ImunisasiVarisela ImunisasiVarisela { get; set; }
        public ImunisasiHPV ImunisasiHPV { get; set; }
        public ImunisasiJapaneseEncephalitis ImunisasiJapaneseEncephalitis { get; set; }
        public ImunisasiDengue ImunisasiDengue { get; set; }

        // Data anak related enity
        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}