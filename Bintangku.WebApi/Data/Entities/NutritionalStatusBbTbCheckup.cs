namespace Bintangku.WebApi.Data.Entities
{
    public class NutritionalStatusBbTbCheckup
    {
        public int NutritionalStatusBbTbCheckupId { get; set; } 
        public int Weight { get; set; }
        public int Height { get; set; }
        public int ZCode { get; set; }
        public string NutritionalStatus { get; set; }
        public string Action { get; set; }

        // Navigation property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}