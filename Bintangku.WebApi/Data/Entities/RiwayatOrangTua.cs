using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("RiwayatOrangTua")]
    public class RiwayatOrangTua
    {
        [Key]
        public int RiwayatOrangTuaId { get; set; }
        public string NamaAyah { get; set; }    
        public DateTime TanggalLahirAyah { get; set; } = DateTime.Now;
        public string PekerjaanAyah { get; set; }
        public string NamaIbu { get; set; }
        public DateTime TanggalLahirIbu { get; set; }
        public string PekerjaanIbu { get; set; }
        public float PenghasilanOrangTua { get; set; }
        public byte AnggotaRumahTangga { get; set; }
        public string TandaTanganPath { get; set; }

        // Data Anak Related Entity
        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}