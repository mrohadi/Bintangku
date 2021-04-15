using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Repository
{
    public class ChildDataRepository : IChildDataRepository
    {
        private readonly ApplicationDataContext _context;
        public ChildDataRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public Task<ChildData> GetChildDataAsync(int childDataId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ChildData>> GetChildDatasAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task PostChildDataAsync(ChildData childData)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateChildDataAsync(int childDataId, ChildData childData)
        {
            throw new System.NotImplementedException();
        }
    }
}