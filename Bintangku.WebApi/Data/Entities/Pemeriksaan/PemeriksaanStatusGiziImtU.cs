namespace Bintangku.WebApi.Data.Entities.Pemeriksaan
{
    public class PemeriksaanStatusGiziImtU
    {
        public int PemeriksaanStatusGiziImtUId { get; set; } 
        public double BeratBadan { get; set; }
        public double TinggiBadan { get; set; }
        public int Umur { get; set; }
        public double IMT { get; set; }
        public int ZCode { get; set; }
        public string StatusGizi { get; set; }
        public string Tindakan { get; set; }

        // Navigation property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}