using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface INakesUserRepository
    {
        /// <summary>
        /// Update nakes user to data  base 
        /// </summary>
        /// <param name="nakesUser">Object to store in data base</param>
        void Update(NakesUser nakesUser);

        /// <summary>
        /// Save all changes to data base 
        /// </summary>
        /// <returns>No return</returns>
        Task<bool> SaveAllAsync();

        /// <summary>
        /// Get list of nakes user from data base 
        /// </summary>
        /// <returns>List of naskes users</returns>
        Task<IEnumerable<NakesUser>>  GetNakesUsersAsync();

        /// <summary>
        /// Get nakes user based on id 
        /// </summary>
        /// <param name="id">Nakes user id</param>
        /// <returns>Spesific nakes user</returns>
        Task<NakesUser> GetNakesUserByIdAsync(int id);

        /// <summary>
        /// Get nakes user based on username 
        /// </summary>
        /// <param name="username">Nakes username</param>
        /// <returns>Spesific nakes user</returns>
        Task<NakesUser> GetNakesUserByUsername(string username);

        /// <summary>
        /// Get nakes user  
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MemberNakesUserDto>> GetMembersAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<MemberNakesUserDto> GetMemberAsync(string username);
    }
}