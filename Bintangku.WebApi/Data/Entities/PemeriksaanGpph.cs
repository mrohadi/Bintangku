using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("PemeriksaanKesehatanGPPH")]
    public class PemeriksaanGpph
    {
        // FIXME: Add question to the table
        public int PemeriksaanGpphId { get; set; } 
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
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }
    }
}