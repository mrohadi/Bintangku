namespace Bintangku.WebApi.Data.Entities.Pemeriksaan
{
    public class PemeriksaanStatusGiziIpTb
    {
        public int PemeriksaanStatusGiziIpTbId { get; set; } 
        public int TinggiBadan { get; set; }
        public int IndeksPanjang { get; set; }
        public int ZCode { get; set; }
        public string StatusGizi { get; set; }
        public string Tindakan { get; set; }

        // Navigation property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}