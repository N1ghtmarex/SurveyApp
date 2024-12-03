using System;
using Application.Users;
using Application.Users.Dtos;
using Domain.Entities;

namespace Application.Users
{
    public partial class UserMapper : IUserMapper
    {
        public User MapToEntity(ValueTuple<CreateUserModel, byte[], byte[]> p1)
        {
            return new User()
            {
                Username = p1.Item1.Username,
                PasswordHash = funcMain1(p1.Item2),
                PasswordSalt = funcMain2(p1.Item3)
            };
        }
        
        private byte[] funcMain1(byte[] p2)
        {
            if (p2 == null)
            {
                return null;
            }
            byte[] result = new byte[p2.Length];
            Array.Copy(p2, 0, result, 0, p2.Length);
            return result;
            
        }
        
        private byte[] funcMain2(byte[] p3)
        {
            if (p3 == null)
            {
                return null;
            }
            byte[] result = new byte[p3.Length];
            Array.Copy(p3, 0, result, 0, p3.Length);
            return result;
            
        }
    }
}