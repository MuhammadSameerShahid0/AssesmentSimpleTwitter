using SimpleTwitter.DTOs.User;
using SimpleTwitter.Models;

namespace SimpleTwitter.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Register(RegisterDto registerDto);
        Task<User> Login(LoginDto loginDto);
        Task<User> GetUserByEmailAsync(string email);
    }
}
