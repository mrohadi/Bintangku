using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;

namespace Bintangku.WebApi.Interfaces.Pemeriksaan
{
    public interface IPemeriksaanStatusGiziBbTbRepository
    {
        /// <summary>
        /// Update status gizi berat badan per tinggi badan
        /// </summary>
        /// <param name="giziBbTbDto">Model status gizi to update</param>
        void Update(PemeriksaanStatusGiziBbTbDto giziBbTbDto);
        /// <summary>
        /// Get list status gizi berat badan per tinggi badan
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>List status gizi berat badan per tinggi badan</returns>
        Task<IEnumerable<PemeriksaanStatusGiziBbTb>> GetStatusGizi(int dataAnakId);
        /// <summary>
        /// Post pemeriksaan status gizi berat badan per tinggi badan
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="giziBbTbDto">Model to save</param>
        /// <returns>No return</returns>
        Task PostPemeriksaanStatusGiziBbTb(int dataAnakId, PemeriksaanStatusGiziBbTbDto giziBbTbDto);

    }
}