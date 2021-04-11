using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IKmpeCheckupRepository
    {
        /// <summary>
        /// Save all changes to data base
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        /// <summary>
        /// GET hasil pemeriksaan kesehatan KMPE anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Return list hasil pemeriksaan kesehatan KMPE anak</returns>
        Task<IEnumerable<KmpeCheckup>> GetKmpeCheckupsAsync(int childDataId);
        /// <summary>
        /// POST hasil pemeriksaan kesehatan KMPE anak to data base
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="pemeriksaanKmpeDto">Data model to transfer to data base</param>
        /// <returns>No return</returns>
        Task PostKmpeCheckupAsync(int childDataId, PemeriksaanKmpeDto pemeriksaanKmpeDto);
    }
}