using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IParentHistoryRepository
    {
        /// <summary>
        /// Update data riwayat orang tua anak
        /// </summary>
        /// <param name="parentHistory">Riwayat orang tua object</param>
        void Update(ParentHistory parentHistory); 
        /// <summary>
        /// Get data riwayat orang tua anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Data riwayat orang tau anak</returns>
        Task<ParentHistory> GetParentHistoryAsync(int childDataId);
    }
}