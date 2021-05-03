using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IPemeriksaanStatusGiziIpTbRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        void Update(PemeriksaanStatusGiziIpTbDto dto);
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
        Task<IEnumerable<PemeriksaanStatusGiziIpTb>> GetStatusGiziIpTbAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task PostStatusGiziIpTbAsync(int dataAnakId, PemeriksaanStatusGiziIpTbDto dto);
    }
}