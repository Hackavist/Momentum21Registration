using MomentumRegistrationApi.Entities;

namespace MomentumRegistrationApi.Services.SecurityService
{
    public interface ISecurityService
    {
        string Createtoken (User user );
        string HashPassword(string password, byte[] salt);
    }
}