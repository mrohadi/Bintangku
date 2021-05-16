namespace Bintangku.WebApi.Data.Entities.Pemeriksaan
{
    public class PemeriksaanDayaLihat
    {
        public int PemeriksaanDayaLihatId { get; set; } 
        public int MataKanan { get; set; }
        public int MataKiri { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Navigation Property
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}