using System.Threading.Tasks;
using Bintangku.Data.Entities;

namespace Bintangku.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(NakesUser nakesUser);
    }
}