namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultKmpe
    {
        public string Interpretasi { get; set; }
        public string Intervensi { get; set; }
        private int _jumlahYa;
        public ResultKmpe(int jumlahYa) 
        {
            _jumlahYa = jumlahYa; 
            
            Result();
        }
        
        public void Result()
        {
            if(_jumlahYa == 1)
            {
                Interpretasi = "Kemungkinan Anak Mengalami Masalah Emosional";
                Intervensi = "Lakukan konseling kepada orang tua menggunakan buku Pola Asuh Yang Mendukung Perkembangan Anak";
            }
            else if(_jumlahYa > 1)
            {
                Interpretasi = "Anak Mengalami Masalah Emosional";
                Intervensi = "Rujuk Anak Kerumah Sakit";
            }
            else
            {
                Interpretasi = "Anak Normal";
                Intervensi = "Tidak Perlu Rujuk";
            }
        }
    }
}