using System;
using System.ComponentModel.DataAnnotations;

namespace Bintangku.WebApi.Data.Entities
{
    public class ChildData
    {
        [Key]
        public int ChildDataId { get; set; }
        public string FullName { get; set; }
        public int NIK { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public string Kontak { get; set; }
        public string ImagePath { get; set; }
        public byte NumberOfSiblings { get; set; }

        // Riwayat Penyakit Related Entity
        public BirthHistory BirthHistory { get; set; }

        // Riwayat Orang Tua Related Entity
        public ParentHistory ParentHistory{ get; set; }
        
        // Kesehatan Anak Related Entity
        public ChildHealth ChildHealth { get; set; }

        // Nakes User relatied entities
        public int NakesUserId { get; set; }
        public NakesUser NakesUser { get; set; }
        
        // Keseahatan Anak realted entity
    }
}