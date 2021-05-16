using System;

namespace Bintangku.WebApi.Data.DTO
{
    public class DataAnakDto
    {
        public int? Id { get; set; }
        public string NamaLengkap { get; set; }
        public int? NIK { get; set; }
        public string JenisKelamin { get; set; }
        public DateTime? TanggalLahirAnak { get; set; }
        public int UmurAnak { get; set; }
        public string NamaAyah { get; set; }
        public string NamaIbu { get; set; }
        public string Alamat { get; set; }
        public string Kontak { get; set; }
    }
}