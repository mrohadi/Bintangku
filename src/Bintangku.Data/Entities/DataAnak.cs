using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.Data.Entities
{
    [Table("DataAnak")]
    public class DataAnak
    {
        public int Id { get; set; }
        public string NamaLengkap { get; set; }
        public int NIK { get; set; }
        public string JenisKelamin { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string NamaAyah { get; set; }
        public string NamaIbu { get; set; }
        public string Alamat { get; set; }
        public string Kontak { get; set; }

        // Relatied entities
        public int NakesUserId { get; set; }
        public NakesUser NakesUser { get; set; }
    }
}