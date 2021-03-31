namespace Bintangku.WebApi.Data.Entities
{
    public class PemeriksaanKpsp
    {
        public int PemeriksaanKpspId { get; set; } 
        public int JumlahYa { get; set; }
        public string Interpretasi { get; set; }
        public string Tindakan { get; set; }

        // Navigation property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}