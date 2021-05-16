using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Interfaces.Imunisasi
{
    public interface IImunisasiPcvRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<ImunisasiDto> GetImunisasiPcvAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateImunisasiPcvAsync(int dataAnakId, ImunisasiDto dto);
    }
}