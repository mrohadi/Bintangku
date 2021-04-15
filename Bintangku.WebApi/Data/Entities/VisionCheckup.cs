namespace Bintangku.WebApi.Data.Entities
{
    public class VisionCheckup
    {
        public int VisionCheckupId { get; set; } 
        public int RightEye { get; set; }
        public int LeftEye { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Navigation Property
        public int ChildHealthId { get; set; }
        public ChildHealth ChildHealth { get; set; }
    }
}