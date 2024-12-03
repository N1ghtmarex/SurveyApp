using Application.Abstractions.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserService(ApplicationDbContext dbContext) : IUserService
    {
        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken, bool includeChoice = false)
        {
            var query = dbContext.Users.
                Where(x => x.Id == id);

            if (includeChoice) {
                query = query.Include(x => x.Choices);
            }

            var user = await query.SingleOrDefaultAsync(cancellationToken);

            return user;
        }

        public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .Where(x => x.Username == username)
                .SingleOrDefaultAsync(cancellationToken);

            return user;
        }
    }
}
