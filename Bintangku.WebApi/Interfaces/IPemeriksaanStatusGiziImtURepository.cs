using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IPemeriksaanStatusGiziImtURepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        void Upload(PemeriksaanStatusGiziImtUDto dto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAllAsync();
        Task<IEnumerable<PemeriksaanStatusGiziImtU>> GetStatusGiziImtUAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnak"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task PostStatusGiziImtUAsync(int dataAnakId, PemeriksaanStatusGiziImtUDto dto);
    }
}