using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities.Imunisasi;

namespace Bintangku.WebApi.Interfaces.Imunisasi
{
    public interface IImunisasiRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ImunisasiAnak>> GetImunisasiAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // Task<IEnumerable<ImunisasiAnak>> GetImunisasisAsync();
    }
}