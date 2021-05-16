using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Interfaces.Imunisasi
{
    public interface IImunisasiVariselaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        Task<ImunisasiDto> GetImunisasiVariselaAsync(int dataAnakId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateImunisasiVariselaAsync(int dataAnakId, ImunisasiDto dto);
    }
}