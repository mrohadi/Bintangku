using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("BirthHistory")]
    public class BirthHistory
    {
        [Key]
        public int BirthHistoryId { get; set; }
        public byte Weight { get; set; }
        public int Length { get; set; }
        public int ApgarScore { get; set; }
        public string BirthAssistedBy { get; set; }
        public string Etc { get; set; }

        // Data Anak Related Entity
        public int ChildDataId { get; set; }
        public ChildData ChildData { get; set; }
    }
}