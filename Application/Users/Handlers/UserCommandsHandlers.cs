using Application.Abstractions.Interfaces;
using Application.Users.Commands;
using Common.Exceptions;
using Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Users.Handlers
{
    internal class UserCommandsHandlers(ApplicationDbContext dbContext, IPasswordService passwordService, IUserService userService, IUserMapper userMapper)
        : IRequestHandler<CreateUserCommand, string>, IRequestHandler<AuthUserCommand, string>
    {
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existedUser = await userService.GetUserByUsernameAsync(request.Body.Username, cancellationToken);

            if (existedUser != null)
            {
                throw new ObjectAlreadyExistsException($"Пользователь с именем \"{request.Body.Username}\" уже существует!");
            }

            passwordService.CreatePasswordHash(request.Body.Password, out var passwordHash, out var passwordSalt);

            var userToCreate = userMapper.MapToEntity((request.Body, passwordHash, passwordSalt));

            var createdUser = await dbContext.Users.AddAsync(userToCreate, cancellationToken);
            await dbContext.SaveChangesAsync();

            return createdUser.Entity.Id.ToString();
        }

        public async Task<string> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByUsernameAsync(request.Body.Username, cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с именем \"{request.Body.Username}\" не найден!");
            }

            if (!passwordService.VerifyPasswordHash(request.Body.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ForbiddenException($"Неправильный пароль!");
            }

            return user.Id.ToString();
        }
    }
}
