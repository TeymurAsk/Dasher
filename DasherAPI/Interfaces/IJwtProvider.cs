using DasherAPI.Data;

namespace DasherAPI.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}