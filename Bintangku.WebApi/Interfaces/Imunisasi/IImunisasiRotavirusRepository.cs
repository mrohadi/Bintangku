using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Interfaces.Imunisasi
{
    public interface IImunisasiRotavirusRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<ImunisasiDto> GetImunisasiRotavirusAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateImunisasiRotavirusAsync(int dataAnakId, ImunisasiDto dto);
    }
}