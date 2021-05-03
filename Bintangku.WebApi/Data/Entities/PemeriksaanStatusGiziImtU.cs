namespace Bintangku.WebApi.Data.Entities
{
    public class PemeriksaanStatusGiziImtU
    {
        public int PemeriksaanStatusGiziImtUId { get; set; } 
        public int BeratBadan { get; set; }
        public int TinggiBadan { get; set; }
        public int Umur { get; set; }
        public int IMT { get; set; }
        public int ZCode { get; set; }
        public string StatusGizi { get; set; }
        public string Tindakan { get; set; }

        // Navigation property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}