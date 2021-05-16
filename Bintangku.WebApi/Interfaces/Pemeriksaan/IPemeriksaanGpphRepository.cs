using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;

namespace Bintangku.WebApi.Interfaces.Pemeriksaan
{
    public interface IPemeriksaanGpphRepository 
    {   
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