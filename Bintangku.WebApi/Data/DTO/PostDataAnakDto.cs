using System;
using System.ComponentModel.DataAnnotations;

namespace Bintangku.Data.DTO
{
    public class PostDataAnakDto
    {
        [Required]
        public string NamaLengkap { get; set; }
        [Required]
        public int NIK { get; set; }
        [Required]
        public string JenisKelaminAnak { get; set; }
        [Required]
        public DateTime TanggalLahirAnak { get; set; } = DateTime.Now;
        [Required]
        public string Alamat { get; set; }
        [Required]
        public string Kontak { get; set; }
        public string ImagePath { get; set; }

        // Riwayat Penyakit dan Pengobatan
        [Required]
        public byte JumlahSaudara { get; set; }

        // Riwayat Kelahiran
        [Required]
        public byte BeratBadan { get; set; }
        [Required]
        public int PanjangLahir { get; set; }
        [Required]
        public int ApgarScore { get; set; }
        [Required]
        public string KelahiranDibantuOleh { get; set; }
        [Required]
        public string LainLain { get; set; }

        // Riwayat Orang Tua
        [Required]
        public string NamaAyah { get; set; }    
        [Required]
        public DateTime TanggalLahirAyah { get; set; } = DateTime.Now;
        [Required]
        public string PekerjaanAyah { get; set; }
        [Required]
        public string NamaIbu { get; set; }
        [Required]
        public DateTime TanggalLahirIbu { get; set; }
        [Required]
        public string PekerjaanIbu { get; set; }
        [Required]
        public float PenghasilanOrangTua { get; set; }
        [Required]
        public byte AnggotaRumahTangga { get; set; }
        [Required]
        public string TandaTanganPath { get; set; }
    }
}