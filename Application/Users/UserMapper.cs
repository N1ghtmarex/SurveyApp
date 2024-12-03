using Application.Users.Dtos;
using Domain.Entities;
using Mapster;

namespace Application.Users
{
    [Mapper]
    public interface IUserMapper
    {
        User MapToEntity((CreateUserModel model, byte[] passwordHash, byte[] passwordSalt) src);
    }

    partial class UserMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateUserModel Model, byte[] PasswordHash, byte[] PasswordSalt), User>()
                .Map(d => d.Username, src => src.Model.Username)
                .Map(d => d.PasswordHash, src => src.PasswordHash)
                .Map(d => d.PasswordSalt, src => src.PasswordSalt);
        }
    }
}
