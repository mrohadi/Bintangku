using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IDataAnakRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DataAnakDto>> GetDataAnaksAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DataAnakDto> GetDataAnakAsync(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataAnak"></param>
        /// <returns></returns>
        Task UpdateDataAnakAsync(int dataAnakId, DataAnak dataAnak);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnak"></param>
        /// <returns></returns>
        Task PostDataAnakAsync(string nakesUsername, PostDataAnakDto dto);
        Task DeleteDataAnakAsync(int dataAnakId);
    }
}