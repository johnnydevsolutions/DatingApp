using DatingProject.Entities;

namespace DatingBack.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}