using Microsoft.EntityFrameworkCore;
using SimpleTwitter.DatabaseContext;
using SimpleTwitter.Interfaces.Twitter;
using SimpleTwitter.Models;

namespace SimpleTwitter.Repository.TwitterPosts
{
    public class TwitterPostRepository : ITwitterPostRepository
    {
        private readonly DataContext _context;

        public TwitterPostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TwitterPost>> GetAllPostsForUserAsync(Guid userId)
        {
            return await _context.TwitterPosts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task AddTwitterPostAsync(TwitterPost post)
        {
            _context.TwitterPosts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TwitterPost>> GetAllPostsAsync()
        {
            return await _context.TwitterPosts
                                 .OrderByDescending(post => post.CreatedAt) // Order by CreatedAt in descending order
                                 .ToListAsync();
        }

        public async Task<TwitterPost> GetTwitterPostByIdAsync(Guid twitterId)
        {
            var result = await _context.TwitterPosts.FirstOrDefaultAsync(tp => tp.TwitterId == twitterId);
            return result;
        }
    }

}
