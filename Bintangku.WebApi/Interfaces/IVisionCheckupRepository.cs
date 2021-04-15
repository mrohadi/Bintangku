using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IVisionCheckupRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="visionCheckup"></param>
        void Update(VisionCheckup visionCheckup); 

        /// <summary>
        /// Save all changes to data base
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        /// <summary>
        /// Get result vision check up
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Return list vision check up</returns>
        Task<IEnumerable<VisionCheckup>> GetVisionCheckupsAsync(int childDataId);
        /// <summary>
        /// POST hasil tes daya lihat anak
        /// </summary>
        /// <param name="childDataId">Unique dataAnakId</param>
        /// <param name="pemeriksaanKmpeDto">Data model to transfer to data base</param>
        /// <returns>No return</returns>
        Task PostVisionCheckupAsync(int childDataId, PemeriksaanDayaLihatDto pemeriksaanDayaLihatDto);
    }
}