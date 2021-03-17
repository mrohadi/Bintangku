using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.Data.Entities
{
    [Table("PhotoAnak")]
    public class PhotoAnak
    {
        public int Id { get; set; } 
        public string Url { get; set; }
        public string PublicId { get; set; }

        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}