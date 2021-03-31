namespace Bintangku.WebApi.Data.Entities
{
    public class PemeriksaanLingkarKepala
    {
        public int PemeriksaanLingkarKepalaId { get; set; }        
        public int LingkarKepala { get; set; }
        public int Kurva { get; set; }
        public string Klasifikasi { get; set; }
        public string Tindakan { get; set; }

        // Navigation property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}