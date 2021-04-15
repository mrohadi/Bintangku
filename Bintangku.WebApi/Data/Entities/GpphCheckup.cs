using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("GpphCheckup")]
    public class GpphCheckup
    {
        // FIXME: Add question to the table
        public int GpphCheckupId { get; set; } 
        public byte Point { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }
        public byte Question1 { get; set; }
        public byte Question2 { get; set; }
        public byte Question3 { get; set; }
        public byte Question4 { get; set; }
        public byte Question5 { get; set; }
        public byte Question6 { get; set; }
        public byte Question7 { get; set; }
        public byte Question8 { get; set; }
        public byte Question9 { get; set; }
        public byte Question10 { get; set; }

        // Kesehatan Anak Related Entity
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}