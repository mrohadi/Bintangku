using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;

namespace Bintangku.WebApi.Interfaces.Pemeriksaan
{
    public interface IPemeriksaanDayaLihatRepository    
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tesDayaLihatDto"></param>
        void Update(PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto); 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Save all changes to data base
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        /// <summary>
        /// GET hasil tes daya lihat anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Return list tes daya lihat</returns>
        Task<IEnumerable<PemeriksaanDayaLihat>> GetTesDayaLihat(int dataAnakId);
        /// <summary>
        /// POST hasil tes daya lihat anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanKmpeDto">Data model to transfer to data base</param>
        /// <returns>No return</returns>
        Task PostDayaLihat(int dataAnakId, PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto);
    }
}