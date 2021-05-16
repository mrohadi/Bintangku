using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Interfaces.Imunisasi
{
    public interface IImunisasiHepatitisARepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<ImunisasiDto> GetImunisasiHepatitisAAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateImunisasiHepatitisAAsync(int dataAnakId, ImunisasiDto dto);
    }
}