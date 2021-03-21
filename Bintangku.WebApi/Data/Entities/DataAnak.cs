using System;
using System.ComponentModel.DataAnnotations;

namespace Bintangku.Data.Entities
{
    public class DataAnak
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NamaLengkap { get; set; }
        [Required]
        public int NIK { get; set; }
        [Required]
        public string JenisKelamin { get; set; }
        [Required]
        public DateTime TanggalLahirAnak { get; set; } = DateTime.Now;
        [Required]
        public string Alamat { get; set; }
        [Required]
        public string Kontak { get; set; }
        public string ImagePath { get; set; }


        // Riwayat Penyakit dan Pengobatan
        public byte JumlahSaudara { get; set; }

        // Riwayat Penyakit Related Entity
        public RiwayatKelahiran RiwayatKelahiran { get; set; }

        // Riwayat Orang Tua Related Entity
        public RiwayatOrangTua RiwayatOrangTua { get; set; }
        
        // Kesehatan Anak Related Entity
        public KesehatanAnak KesehatanAnak { get; set; }

        // Nakes User relatied entities
        public int UserId { get; set; }
        public NakesUser NakesUser { get; set; }
        
        // Keseahatan Anak realted entity
    }
}