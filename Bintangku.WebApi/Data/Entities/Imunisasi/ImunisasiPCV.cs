using System.ComponentModel.DataAnnotations;

namespace Bintangku.WebApi.Data.Entities.Imunisasi
{
    public class ImunisasiPCV
    {
        [Key]
        public int ImunisasiPCVId { get; set; }
        public byte? Lahir { get; set; }       
        public byte? Bulan1 { get; set; }
        public byte? Bulan2 { get; set; }
        public byte? Bulan3 { get; set; }
        public byte? Bulan4 { get; set; }
        public byte? Bulan5 { get; set; }
        public byte? Bulan6 { get; set; }
        public byte? Bulan9 { get; set; }
        public byte? Bulan12 { get; set; }
        public byte? Bulan15 { get; set; }
        public byte? Bulan18 { get; set; }
        public byte? Bulan24 { get; set; }
        public byte? Tahun3 { get; set; }
        public byte? Tahun5 { get; set; }
        public byte? Tahun6 { get; set; }
        public byte? Tahun7 { get; set; }
        public byte? Tahun8 { get; set; }
        public byte? Tahun9 { get; set; }
        public byte? Tahun10 { get; set; }
        public byte? Tahun12 { get; set; }
        public byte? Tahun18 { get; set; }

        public int ImunisasiAnakId { get; set; }
        public ImunisasiAnak ImunisasiAnak { get; set; }
    }
}