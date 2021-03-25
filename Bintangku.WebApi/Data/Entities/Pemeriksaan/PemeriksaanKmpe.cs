using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.Data.Entities
{
    [Table("PemeriksaanKesehatanKMPE")]
    public class PemeriksaanKmpe
    {
        public int PemeriksaanKmpeId { get; set; } 
        public byte JumlahYa { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Kesehatan Anak Related Entity
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}