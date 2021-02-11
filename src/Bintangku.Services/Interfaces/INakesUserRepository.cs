using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;

namespace Bintangku.Services.Interfaces
{
    public interface INakesUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nakesUser"></param>
        void Update(NakesUser nakesUser);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NakesUser>>  GetNakesUsersAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<NakesUser> GetNakesUserByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<NakesUser> GetNakesUserByUsername(string username);

        /// <summary>
        /// 
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