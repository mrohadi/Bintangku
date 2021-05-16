using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities.Pemeriksaan
{
    [Table("PemeriksaanKesehatanKMPE")]
    public class PemeriksaanKmpe
    {
        // FIXME: Add qustion to the table
        public int PemeriksaanKmpeId { get; set; } 
        public byte JumlahYa { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }
        public bool Question1 { get; set; }
        public bool Question2 { get; set; }
        public bool Question3 { get; set; }
        public bool Question4 { get; set; }
        public bool Question5 { get; set; }
        public bool Question6 { get; set; }
        public bool Question7 { get; set; }
        public bool Question8 { get; set; }
        public bool Question9 { get; set; }
        public bool Question10 { get; set; }
        public bool Question11 { get; set; }
        public bool Question12 { get; set; }
        public bool Question13 { get; set; }
        public bool Question14 { get; set; }

        // Kesehatan Anak Related Entity
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}