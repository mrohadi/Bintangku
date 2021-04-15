namespace Bintangku.WebApi.Data.Entities
{
    public class KpspDetail
    {
        public int KpspDetailId { get; set; }
        public int Age { get; set; }
        public string Question { get; set; }
        public int JumlahYa { get; set; }
        public int GerakKasar { get; set; }
        public int GerakHalus { get; set; }
        public int BicaraDanBahasa { get; set; }
        public int SosialisasiDanKemandirian { get; set; }
        public string Interpretasi { get; set; }
        public string Tindakan { get; set; }


        // Navigation property PemeriksaanKpsp
        public int KpspCheckupId { get; set; }
        public KpspCheckup KpspCheckup { get; set; }

        
    }
}