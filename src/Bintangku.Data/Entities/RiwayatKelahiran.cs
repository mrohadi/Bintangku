namespace Bintangku.Data.Entities
{
    public class RiwayatKelahiran
    {
        public int Id { get; set; }
        public byte BeratBadan { get; set; }
        public int PanjangLahir { get; set; }
        public int ApgarScore { get; set; }
        public string KelahiranDibantuOleh { get; set; }
        public string LainLain { get; set; }

        // Data Anak Related Entity
        public int DataAnakId { get; set; }
        public DataAnak DataAnak { get; set; }
    }
}