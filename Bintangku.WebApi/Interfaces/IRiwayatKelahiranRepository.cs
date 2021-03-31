using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IRiwayatKelahiranRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="riwayatKelahiran"></param>
        void Update(RiwayatKelahiran riwayatKelahiran);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAllAsync();
        /// <summary>
        /// Get riwayat kelahiran anak 
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Data riwayat kelahiran anak</returns>
        Task<RiwayatKelahiran> GetRiwayatKelahiran(int dataAnakId);
    }
}