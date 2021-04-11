using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("ParentHistory")]
    public class ParentHistory
    {
        [Key]
        public int ParentHistoryId { get; set; }
        public string FatherName { get; set; }    
        public DateTime FatherDateOfBirth { get; set; } = DateTime.Now;
        public string FatherJob { get; set; }
        public string MotherName { get; set; }
        public DateTime MotherDateOfBirth { get; set; }
        public string MotherJob { get; set; }
        public float ParentIncome { get; set; }
        public byte HouseholdMember { get; set; }
        public string SignaturePath { get; set; }

        // Data Anak Related Entity
        public int ChildDataId { get; set; }
        public ChildData ChildData { get; set; }
    }
}