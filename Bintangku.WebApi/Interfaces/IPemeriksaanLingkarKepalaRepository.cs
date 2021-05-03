using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
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
        /// <returns></returns>
        Task<bool> SaveAllAsync();
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