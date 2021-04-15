using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IMchatCheckupRepository
    {
        /// <summary>
        /// Save all object to data
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        /// <summary>
        /// Get hasil pemeriksaan MCHAT anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>List hasil pemeriksaan MCHAT anak</returns>
        Task<IEnumerable<MchatCheckup>> GetMchatCheckupAsync(int childDataId);
        /// <summary>
        /// Post hasil pemeriksaan kesehatan MCHAT anak to data base
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="pemeriksaanMchatDto">Pemeriksaan MCHAT object</param>
        /// <returns>No return</returns>
        Task PostMchatCheckupAsync(int childDataId, PemeriksaanMchatDto pemeriksaanMchatDto); 
    }
}