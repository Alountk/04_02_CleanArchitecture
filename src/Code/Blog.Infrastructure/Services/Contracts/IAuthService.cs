using Blog.Core.Entities;

namespace Blog.Infrastructure.Services.Contracts
{
    public interface IAuthService
    {
        string GenerateToken(DateTime actualDate, User user, TimeSpan validateTime);
    }
}