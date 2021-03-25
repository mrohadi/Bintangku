using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.Data.Entities
{
    [Table("PemeriksaanKesehatanM-CHAT")]
    public class PemeriksaanMchat
    {
        public int PemeriksaanMchatId { get; set; } 
        public int JumlahYa { get; set; }
        public int JumlahTidak { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Kesehatan Anak Related Entity 
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}