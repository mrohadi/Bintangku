using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IBirthHistoryRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="birthHistory"></param>
        void Update(BirthHistory birthHistory);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAllAsync();
        /// <summary>
        /// Get riwayat kelahiran anak 
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Data riwayat kelahiran anak</returns>
        Task<BirthHistory> GetBirthHistoryAsync(int childDataId);
    }
}