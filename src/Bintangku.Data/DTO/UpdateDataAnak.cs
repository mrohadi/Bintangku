using System;

namespace Bintangku.Data.DTO
{
    public class UpdateDataAnak
    {
        public string NamaLengkap { get; set; }
        public int NIK { get; set; }
        public string JenisKelaminAnak { get; set; }
        public DateTime TanggalLahirAnak { get; set; } = DateTime.Now;
        public string PhotoAnakUrl { get; set; }
        public string Alamat { get; set; }
        public string Kontak { get; set; }
        
        // Riwayat Penyakit dan Pengobatan
        public byte JumlahSaudara { get; set; }

        // Riwayat Kelahiran
        public byte BeratBadan { get; set; }
        public int PanjangLahir { get; set; }
        public int ApgarScore { get; set; }
        public string KelahiranDibantuOleh { get; set; }
        public string LainLain { get; set; }

        // Riwayat Orang Tua
        public string NamaAyah { get; set; }    
        public DateTime TanggalLahirAyah { get; set; } = DateTime.Now;
        public string PekerjaanAyah { get; set; }
        public string NamaIbu { get; set; }
        public DateTime TanggalLahirIbu { get; set; }
        public string PekerjaanIbu { get; set; }
        public float PenghasilanOrangTua { get; set; }
        public byte AnggotaRumahTangga { get; set; }
        public string TandaTanganOrangTua { get; set; }
    }
}