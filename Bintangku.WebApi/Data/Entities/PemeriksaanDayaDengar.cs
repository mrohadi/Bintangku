namespace Bintangku.WebApi.Data.Entities
{
    public class PemeriksaanDayaDengar
    {
        public int PemeriksaanDayaDengarId { get; set; } 
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Navigation property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}