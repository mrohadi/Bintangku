using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface IChildDataRepository
    {
        /// <summary>
        /// Update child data to data base
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="childData">Object child data to update</param>
        /// <returns>No return</returns>
        Task UpdateChildDataAsync(int childDataId, ChildData childData);
        /// <summary>
        /// Save all child data changes
        /// </summary>
        /// <returns>Return booolean</returns>
        Task<bool> SaveAllAsync();
        /// <summary>
        /// Get list child data
        /// </summary>
        /// <returns>List child data</returns>
        Task<IEnumerable<ChildData>> GetChildDatasAsync();
        /// <summary>
        /// Get specific child data based on childDataId
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Specific child data based on childDataId</returns>
        Task<ChildData> GetChildDataAsync(int childDataId);
        /// <summary>
        /// Post child data from data base
        /// </summary>
        /// <param name="childData">Object child data to save</param>
        /// <returns>No return</returns>
        Task PostChildDataAsync(ChildData childData);

    }
}