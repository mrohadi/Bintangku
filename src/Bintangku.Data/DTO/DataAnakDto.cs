using System;
using Bintangku.Data.Entities;

namespace Bintangku.Data.DTO
{
    public class DataAnakDto
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
        public MemberNakesUserDto MemberNakesUserDto { get; set; }
    }
}