using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IRiwayatOrangTuaRepository
    {
        /// <summary>
        /// Update data riwayat orang tua anak
        /// </summary>
        /// <param name="riwayatOrangTua">Riwayat orang tua object</param>
        void Update(RiwayatOrangTua riwayatOrangTua); 
        /// <summary>
        /// Get data riwayat orang tua anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Data riwayat orang tau anak</returns>
        Task<RiwayatOrangTua> GetRiwayatOrangTuaAsync(int dataAnakId);
    }
}