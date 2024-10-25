using SimpleTwitter.Models;

namespace SimpleTwitter.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByUsernameAsync(string username); 
    Task<User> GetUserByIdAsync(Guid userId);
    Task<bool> RegisterUserAsync(User user);
    Task<IEnumerable<TwitterPost>> GetAllPostsAsync();
}
