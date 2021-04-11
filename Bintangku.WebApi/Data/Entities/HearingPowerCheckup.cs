using System.Collections.Generic;

namespace Bintangku.WebApi.Data.Entities
{
    public class HearingPowerCheckup
    {
        public int HearingPowerCheckupId { get; set; } 

        // Navigation property for DayaDengarDetail
        public ICollection<HearingPowerDetail> HearingPowerDetails { get; set; }

        // Navigation property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}