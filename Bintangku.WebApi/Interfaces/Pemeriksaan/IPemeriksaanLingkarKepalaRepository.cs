using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;

namespace Bintangku.WebApi.Interfaces.Pemeriksaan
{
    public interface IPemeriksaanLingkarKepalaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        void Update(PemeriksaanLingkarKepalaDto dto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<IEnumerable<PemeriksaanLingkarKepala>> GetLingkarKepalaAsync(int dataAnakId);
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task PostLingkatKepalaAsync(int dataAnakId, PemeriksaanLingkarKepalaDto dto);
    }
}