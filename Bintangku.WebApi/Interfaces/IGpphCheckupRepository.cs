using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IGpphCheckupRepository
    {
        /// <summary>
        /// Save object to data base 
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        
        /// <summary>
        /// GET hasil pemeriksaan kesehatan GPPH anak
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        Task<IEnumerable<GpphCheckup>> GetGpphCheckupsAsync(int childDataId);
       
        /// <summary>
        /// POST pemeriksaan kesehatan GPPH anak 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        Task PostGpphCheckupAsync(int childDataId, PemeriksaanGpphDto pemeriksaanGpphDto);
    }
}