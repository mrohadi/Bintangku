using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("PemeriksaanKesehatanGPPH")]
    public class PemeriksaanGpph
    {
        public int PemeriksaanGpphId { get; set; } 
        public byte Point { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Kesehatan Anak Related Entity
        public int KesehatanAnakId { get; set; }
        public KesehatanAnak KesehatanAnak { get; set; }

        public static explicit operator PemeriksaanGpph(List<object> v)
        {
            throw new NotImplementedException();
        }
    }
}