using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Interfaces.Imunisasi
{
    public interface IImunisasiDengueRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<ImunisasiDto> GetImunisasiDengueAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateImunisasiDengueAsync(int dataAnakId, ImunisasiDto dto);
    }
}