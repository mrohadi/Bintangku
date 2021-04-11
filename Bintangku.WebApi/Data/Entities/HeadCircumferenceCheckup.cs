namespace Bintangku.WebApi.Data.Entities
{
    public class HeadCircumferenceCheckup
    {
        public int HeadCircumferenceCheckupId { get; set; }        
        public int HeadCircumference { get; set; }
        public int Curve { get; set; }
        public string Classification { get; set; }
        public string Action { get; set; }

        // Navigation property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}