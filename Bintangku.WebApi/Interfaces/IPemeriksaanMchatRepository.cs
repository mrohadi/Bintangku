using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IPemeriksaanMchatRepository
    {
        /// <summary>
        /// Save all object to data
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        /// <summary>
        /// Get hasil pemeriksaan MCHAT anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>List hasil pemeriksaan MCHAT anak</returns>
        Task<IEnumerable<PemeriksaanMchat>> GetPemeriksaanMchat(int dataAnakId);
        /// <summary>
        /// Post hasil pemeriksaan kesehatan MCHAT anak to data base
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanMchatDto">Pemeriksaan MCHAT object</param>
        /// <returns>No return</returns>
        Task PostPemeriksaanMchat(int dataAnakId, PemeriksaanMchatDto pemeriksaanMchatDto); 
    }
}