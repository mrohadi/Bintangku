using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("KesehatanAnak")]
    public class KesehatanAnak
    {
        [Key]
        public int KesehatanAnakId { get; set; } 
        public int PemeriksaanBeratBadan { get; set; }
        public int PemeriksaanTinggiBadan { get; set; }
        public ICollection<PemeriksaanLingkarKepala> PemeriksaanLingkarKepalas { get; set; }
        public ICollection<PemeriksaanStatusGiziBbTb> PemeriksaanStatusGiziBbTbs { get; set; }
        public ICollection<PemeriksaanStatusGiziImtU> PemeriksaanStatusGiziImtUs { get; set; }
        public ICollection<PemeriksaanStatusGiziIpTb> PemeriksaanStatusGiziIpTbs { get; set; }
        public ICollection<PemeriksaanKpsp> PemeriksaanKpsps { get; set; }
        public ICollection<PemeriksaanDayaDengar> PemeriksaanDayaDengars { get; set; }
        public ICollection<PemeriksaanDayaLihat> PemeriksaanDayaLihats { get; set; }
        public ICollection<PemeriksaanGpph> PemeriksaanGpphs { get; set; }
        public ICollection<PemeriksaanMchat> PemeriksaanMchats { get; set; }
        public ICollection<PemeriksaanKmpe> PemeriksaanKmpes { get; set; }
        
        // Data Anak Related Entity
        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}