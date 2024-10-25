using SimpleTwitter.Models;

namespace SimpleTwitter.Interfaces.Twitter
{
    public interface ITwitterPostRepository
    {
        Task<IEnumerable<TwitterPost>> GetAllPostsForUserAsync(Guid userId);
        Task<TwitterPost> GetTwitterPostByIdAsync(Guid twitterId);
        Task AddTwitterPostAsync(TwitterPost post);
        Task<IEnumerable<TwitterPost>> GetAllPostsAsync();  // Fetch all posts

    }

}
