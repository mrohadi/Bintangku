using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface INutritionalStatusIpTbCheckupRepository
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
        /// <param name="childDataId"></param>
        /// <returns></returns>
        Task<IEnumerable<NutritionalStatusIpTbCheckup>> GetNutritionalStatusIpTbCheckupsAsync(int childDataId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task PostNutritionalStatusIpTbChekcupAsync(int childDataId, PemeriksaanStatusGiziIpTbDto dto);
    }
}