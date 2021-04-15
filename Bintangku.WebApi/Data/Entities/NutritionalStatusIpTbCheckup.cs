namespace Bintangku.WebApi.Data.Entities
{
    public class NutritionalStatusIpTbCheckup
    {
        public int NutritionalStatusIpTbCheckupId { get; set; } 
        public int Height { get; set; }
        public int IndexLength { get; set; }
        public int ZCode { get; set; }
        public string NutritionalStatus { get; set; }
        public string Action { get; set; }

        // Navigation property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}