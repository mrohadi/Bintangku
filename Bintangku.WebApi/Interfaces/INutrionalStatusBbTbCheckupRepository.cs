using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface INutritionalStatusBbTbCheckupRepository
    {
        /// <summary>
        /// Update status gizi berat badan per tinggi badan
        /// </summary>
        /// <param name="bbTbCheckup">Model status gizi to update</param>
        void Update(NutritionalStatusBbTbCheckup bbTbCheckup);
        Task<bool> SaveAllAsync();
        /// <summary>
        /// Get list status gizi berat badan per tinggi badan
        /// </summary>
        /// <param name="childDataId">Unique dataAnakId</param>
        /// <returns>List status gizi berat badan per tinggi badan</returns>
        Task<IEnumerable<NutritionalStatusBbTbCheckup>> GetNutritionalStatusBbTbCheckupsAsync(int childDataId);
        /// <summary>
        /// Post pemeriksaan status gizi berat badan per tinggi badan
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="giziBbTbDto">Model to save</param>
        /// <returns>No return</returns>
        Task PostNutritionalStatusBbTbCheckupAsync(int childDataId, PemeriksaanStatusGiziBbTbDto giziBbTbDto);

    }
}