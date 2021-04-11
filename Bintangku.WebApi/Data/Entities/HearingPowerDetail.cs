namespace Bintangku.WebApi.Data.Entities
{
    public class HearingPowerDetail
    {
        public int HearingPowerDetailId{ get; set; }
        public int Age { get; set; }
        public int TotalYes { get; set; }
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }

        // Navigation property for PemeriksaanDayaDengar
        public int HearingPowerCheckupId { get; set; }
        public HearingPowerCheckup HearingPowerCheckup { get; set; }
    }
}