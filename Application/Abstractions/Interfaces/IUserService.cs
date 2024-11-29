using Domain.Entities;

namespace Application.Abstractions.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByUsernameAsync(string id, CancellationToken cancellationToken);
    }
}
