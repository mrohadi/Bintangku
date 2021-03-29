using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IDataAnakRepository
    {
        void Update(DataAnak dataAnak);
        Task<bool> SaveAllAsync();
        Task<ActionResult<IEnumerable<DataAnakDto>>> GetDataAnaksAsync();
        Task<ActionResult<DataAnakDto>> GetDataAnakAsync(int id);
        Task<IActionResult> UpdateDataAnakAsync(int id, DataAnak dataAnak);
        Task<ActionResult<DataAnak>> CreateDataAnakAsync(DataAnak dataAnak);

    }
}