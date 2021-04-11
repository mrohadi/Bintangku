using System.Collections.Generic;

namespace Bintangku.WebApi.Data.Entities
{
    public class KpspCheckup
    {
        public int KpspCheckupId { get; set; } 

        // Navigation Property for KpspDetail
        public ICollection<KpspDetail> KpspDetails { get; set; }

        // Navigation property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}