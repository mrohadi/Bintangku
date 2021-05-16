using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IRiwayatKelahiranRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="riwayatKelahiran"></param>
        /// <returns></returns>
        Task UpdateRiwayatKelahiran(int dataAnakId, RiwayatKelahiran riwayatKelahiran);
        /// <summary>
        /// Get riwayat kelahiran anak 
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Data riwayat kelahiran anak</returns>
        Task<RiwayatKelahiran> GetRiwayatKelahiran(int dataAnakId);
    }
}