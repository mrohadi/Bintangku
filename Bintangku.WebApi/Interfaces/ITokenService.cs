using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(NakesUser nakesUser);
    }
}