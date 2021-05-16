using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;

namespace Bintangku.WebApi.Pemeriksaan
{
    public class ResultMchat
    {
        public int TotalQuestionYes { get; set; } = 0;
        public int TotalQuestionNo { get; set; } = 0;
        public int TotalCirticalQuestionYes { get; set; } = 0;
        public int TotalCriticalQuestionNo { get; set; } = 0;
        public string Interpretasi { get; set; } = "";
        public string Intervensi { get; set; } = "";
        private readonly PemeriksaanMchatDto _pemeriksaanMchatDto;
        public ResultMchat(PemeriksaanMchatDto pemeriksaanMchatDto)         
        {
            _pemeriksaanMchatDto = pemeriksaanMchatDto;
            
            TotalAnswer();

            Result();   
        }
        
        /// <summary>
        /// Calculate the total answer for both normal and critical question
        /// </summary>
        public void TotalAnswer()
        {
            try
            {
                // FIXME: Find the best way to test this
                if(_pemeriksaanMchatDto.Question1 == true)
                {
                    TotalQuestionYes++;
                    TotalCirticalQuestionYes++;
                }
                else
                {
                    TotalQuestionNo++;
                    TotalCriticalQuestionNo++;
                }

                if(_pemeriksaanMchatDto.Question2 == true) 
                {
                    TotalQuestionYes++;
                    TotalCirticalQuestionYes++;
                }
                else
                {
                    TotalQuestionNo++;
                    TotalCriticalQuestionNo++;
                }
                
                if(_pemeriksaanMchatDto.Question3 == true)
                {
                    TotalQuestionYes++;
                    TotalCirticalQuestionYes++;
                }
                else
                {
                    TotalQuestionNo++;
                    TotalCriticalQuestionNo++;
                }
                
                if(_pemeriksaanMchatDto.Question4 == true)
                {
                    TotalQuestionYes++;
                    TotalCirticalQuestionYes++;
                }
                else
                {
                    TotalQuestionNo++;
                    TotalCriticalQuestionNo++;
                }

                if(_pemeriksaanMchatDto.Question5 == true)
                {
                    TotalQuestionYes++;
                    TotalCirticalQuestionYes++;
                }
                else
                {
                    TotalQuestionNo++;
                    TotalCriticalQuestionNo++;
                }

                if(_pemeriksaanMchatDto.Question6 == true)
                {
                    TotalQuestionYes++;
                    TotalCirticalQuestionYes++;
                }
                else
                {
                    TotalQuestionNo++;
                    TotalCriticalQuestionNo++;
                }

                if(_pemeriksaanMchatDto.Question7 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question8 == true) 
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question9 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question10 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question11 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question12 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question13 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question14 == true) 
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question15 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question16 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question17 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question18 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question19 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question20 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question21 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question22 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;

                if(_pemeriksaanMchatDto.Question23 == true)
                    TotalQuestionYes++;
                else
                    TotalQuestionNo++;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determine the result based on total answered question
        /// </summary>
        public void Result()
        {
            if(TotalCriticalQuestionNo >= 2 || TotalQuestionNo >= 3)
            {
                Interpretasi = "Memiliki Resiko Autisme";
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