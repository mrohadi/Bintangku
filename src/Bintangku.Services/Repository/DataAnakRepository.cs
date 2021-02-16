using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.Services.Repository
{
    public class DataAnakRepository : IDataAnakRepository
    {
        private readonly ApplicationDataContext _context;
        public DataAnakRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public Task<ActionResult<DataAnak>> CreateDataAnakAsync(DataAnak dataAnak)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<DataAnakDto>> GetDataAnakAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<DataAnakDto>>> GetDataAnaksAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(DataAnak dataAnak)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> UpdateDataAnakAsync(int id, DataAnak dataAnak)
        {
            throw new System.NotImplementedException();
        }
    }
}