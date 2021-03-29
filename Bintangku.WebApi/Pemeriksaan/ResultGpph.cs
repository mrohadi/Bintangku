namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultGpph
    {
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }
        public int _point;
        public ResultGpph(int point) 
        {
            _point = point;

            Result();
        }
        
        public void Result() 
        {
            if(_point >= 13)
            {
                Interpretasi = "GPPH";
                Intervensi = "Rujuk Kerumah Sakit";
            }
            else
            {
                Interpretasi = "Normal";
                Intervensi = "Tidak Perlu Rujuk Kerumah Sakit";
            }
        }
    }
}