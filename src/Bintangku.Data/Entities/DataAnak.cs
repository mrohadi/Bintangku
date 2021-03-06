using System;

namespace Bintangku.Data.Entities
{
    public class DataAnak
    {
        public int Id { get; set; }
        public string NamaLengkap { get; set; }
        public int NIK { get; set; }
        public string JenisKelamin { get; set; }
        public DateTime TanggalLahirAnak { get; set; } = DateTime.Now;
        public string PhotoAnakUrl { get; set; }
        public string Alamat { get; set; }
        public string Kontak { get; set; }

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