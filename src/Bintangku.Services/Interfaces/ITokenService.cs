using Bintangku.Data.Entities;

namespace Bintangku.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(NakesUser nakesUser);
    }
}