using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bintangku.WebApi.Data.Entities
{
    [Table("ChildHealth")]
    public class ChildHealth
    {
        [Key]
        public int ChildHealthId { get; set; } 
        public int PemeriksaanBeratBadan { get; set; }
        public int PemeriksaanTinggiBadan { get; set; }
        public ICollection<HeadCircumferenceCheckup> HeadCircumferenceCheckups { get; set; }
        public ICollection<NutritionalStatusBbTbCheckup> NutritionalStatusBbTbCheckups { get; set; }
        public ICollection<NutritionalStatusImtUCheckup> NutritionalStatusImtUCheckups { get; set; }
        public ICollection<NutritionalStatusIpTbCheckup> NutritionalStatusIpTbCheckups { get; set; }
        public ICollection<KpspCheckup> KpspCheckups { get; set; }
        public ICollection<HearingPowerCheckup> hearingPowerCheckups { get; set; }
        public ICollection<VisionCheckup> VisionCheckups { get; set; }
        public ICollection<GpphCheckup> GpphCheckups { get; set; }
        public ICollection<MchatCheckup> MchatCheckups { get; set; }
        public ICollection<KmpeCheckup> KmpeCheckups { get; set; }
        
        // Data Anak Related Entity
        public int ChildDataId { get; set; }
        public ChildData ChildData { get; set; }
    }
}