using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.Services.Interfaces
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