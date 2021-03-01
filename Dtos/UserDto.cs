using System;

namespace MomentumRegistrationApi.Dtos
{
    public record UserResponseDto
    {
        public Guid Id { get; init; }
        public DateTimeOffset CreationDateTime { get; init; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
    public record UserRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public record LoginRequest
    {
        public string username { get; set; }
        public string Password { get; set; }
    }
    public record LoginResponse
    {
        public string username { get; set; }
        public string Token { get; set; }
        public double Expiry { get; set; }
    }

}