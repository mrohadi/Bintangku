using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface INutritionalStatusImtUCheckupRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        void Upload(PemeriksaanStatusGiziImtUDto dto);
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
        Task<IEnumerable<NutritionalStatusImtUCheckup>> GetNutritionalStatusImtUCheckupsAsync(int childDataId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task PostNutritionalStatusImtUCheckupAsync(int childDataId, PemeriksaanStatusGiziImtUDto dto);
    }
}