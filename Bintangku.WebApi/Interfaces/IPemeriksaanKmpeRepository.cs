using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IPemeriksaanKmpeRepository
    {
        /// <summary>
        /// Save all changes to data base
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync(); 
        /// <summary>
        /// GET hasil pemeriksaan kesehatan KMPE anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Return list hasil pemeriksaan kesehatan KMPE anak</returns>
        Task<IEnumerable<PemeriksaanKmpe>> GetPemeriksaanKmpe(int dataAnakId);
        /// <summary>
        /// POST hasil pemeriksaan kesehatan KMPE anak to data base
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanKmpeDto">Data model to transfer to data base</param>
        /// <returns>No return</returns>
        Task PostPemeriksaanKmpe(int dataAnakId, PemeriksaanKmpeDto pemeriksaanKmpeDto);
    }
}