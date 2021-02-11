using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.Services.Repository
{
    public class NakesUserRepository : INakesUserRepository
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        public NakesUserRepository(
            ApplicationDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<MemberNakesUserDto> GetMemberAsync(string username)
        {
            return await _context.NakesUsers
                .Where(x => x.UserName == username)
                .ProjectTo<MemberNakesUserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MemberNakesUserDto>> GetMembersAsync()
        {
            return await _context.NakesUsers
                .ProjectTo<MemberNakesUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

          /// <summary>
          /// 
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
        public async Task<NakesUser> GetNakesUserByIdAsync(int id)
        {
            return await _context.NakesUsers.FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<NakesUser> GetNakesUserByUsername(string username)
        {
            return await _context.NakesUsers
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<NakesUser>> GetNakesUsersAsync()
        {
            return await _context.NakesUsers
                .Include(p => p.Photos)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nakesUser"></param>
        public void Update(NakesUser nakesUser)
        {
            _context.Entry(nakesUser).State = EntityState.Modified;
        }
    }
}