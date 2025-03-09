using webApp.Models;

namespace webApp.Repository;

public interface ITokenService
{
    string CreateToken(AppUser user);
}