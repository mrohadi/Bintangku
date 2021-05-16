using System;
using System.ComponentModel.DataAnnotations;
using Bintangku.WebApi.Data.Entities.Imunisasi;

namespace Bintangku.WebApi.Data.Entities
{
    public class DataAnak
    {
        [Key]
        public int DataAnakId { get; set; }
        public string NamaLengkap { get; set; }
        public int? NIK { get; set; }
        public string JenisKelamin { get; set; }
        public DateTime TanggalLahirAnak { get; set; } = DateTime.Now;
        public int UmurAnak { get; set; }
        public string Alamat { get; set; }
        public string Kontak { get; set; }
        public string ImagePath { get; set; }
        public byte? JumlahSaudara { get; set; }

        // Riwayat Penyakit Related Entity
        public RiwayatKelahiran RiwayatKelahiran { get; set; }

        // Riwayat Orang Tua Related Entity
        public RiwayatOrangTua RiwayatOrangTua { get; set; }
        
        // Kesehatan Anak Related Entity
        public KesehatanAnak KesehatanAnak { get; set; }

        // Imunisasi anak related entity
        public ImunisasiAnak ImunisasiAnak { get; set; }

        // Nakes User relatied entities
        public int NakesUserId { get; set; }
        public NakesUser NakesUser { get; set; }
    }
}