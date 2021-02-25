using System;

namespace Bintangku.Data.Entities
{
    public class RiwayatOrangTua
    {
        public int Id { get; set; }
        public string NamaAyah { get; set; }    
        public DateTime TanggalLahirAyah { get; set; } = DateTime.Now;
        public string PekerjaanAyah { get; set; }
        public string NamaIbu { get; set; }
        public DateTime TanggalLahirIbu { get; set; }
        public string PekerjaanIbu { get; set; }
        public float PenghasilanOrangTua { get; set; }
        public byte AnggotaRumahTangga { get; set; }
        public string TandaTanganOrangTua { get; set; }

        // Data Anak Related Entity
        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}