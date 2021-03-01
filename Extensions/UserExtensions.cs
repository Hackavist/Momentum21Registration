using System;
using MomentumRegistrationApi.Dtos;
using MomentumRegistrationApi.Entities;
namespace MomentumRegistrationApi.Extensions
{
    public static class UserExtensions
    {
        public static UserResponseDto AsResponseDto(this User item)
        {

            return new UserResponseDto
            {
                Id = item.Id,
                CreationDateTime = item.CreationDateTime,
                Username = item.Username,
                Role = item.Role
            };
        }

        public static User AsUser(this UserRequestDto item)
        {

            return new User
            {
                Id = Guid.NewGuid(),
                CreationDateTime = DateTimeOffset.UtcNow,
                Username = item.Username,
                Password = item.Password,
                Role = item.Role
            };
        }
    }
}