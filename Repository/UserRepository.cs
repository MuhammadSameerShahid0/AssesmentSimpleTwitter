using Microsoft.EntityFrameworkCore;
using SimpleTwitter.DatabaseContext;
using SimpleTwitter.Interfaces;
using SimpleTwitter.Models;

namespace SimpleTwitter.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<TwitterPost>> GetAllPostsAsync()
        {
            return await _context.TwitterPosts.Include(p => p.User).ToListAsync();
        }

    }

}
