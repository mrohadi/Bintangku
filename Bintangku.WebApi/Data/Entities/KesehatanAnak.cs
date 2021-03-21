using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.Data.Entities
{
    [Table("KesehatanAnak")]
    public class KesehatanAnak
    {
        public int Id { get; set; } 
        public int PemeriksaanBeratBadan { get; set; }
        public int PemeriksaanTinggiBadan { get; set; }
        public int Imt { get; set; }
        public string LingkarKepala { get; set; }
        public string StatusGiziBbTb { get; set; }
        public string StatusGiziImtU { get; set; }
        public string StatusGiziIpTb { get; set; }
        public string Kpsp { get; set; }
        public string DayaDengar { get; set; }
        public string DayaLihat { get; set; }
        public string Kmpe { get; set; }
        public string Mchat { get; set; }
        public string Gpph { get; set; }
        
        // Data Anak Related Entity
        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}