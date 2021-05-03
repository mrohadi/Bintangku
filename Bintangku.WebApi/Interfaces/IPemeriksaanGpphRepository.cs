using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IPemeriksaanGpphRepository
    {
        /// <summary>
        /// Save object to data base 
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        
        /// <summary>
        /// GET hasil pemeriksaan kesehatan GPPH anak
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<IEnumerable<PemeriksaanGpph>> GetPemeriksaanGpph(int dataAnakId);
       
        /// <summary>
        /// POST pemeriksaan kesehatan GPPH anak 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task PostPemeriksaanGpph(int dataAnakId, PemeriksaanGpphDto pemeriksaanGpphDto);
    }
}