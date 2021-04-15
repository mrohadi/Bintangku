namespace Bintangku.WebApi.Data.Entities
{
    public class NutritionalStatusImtUCheckup
    {
        public int NutritionalStatusImtUCheckupId { get; set; } 
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public int IMT { get; set; }
        public int ZCode { get; set; }
        public string NutritionalStatus { get; set; }
        public string Action { get; set; }

        // Navigation property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}