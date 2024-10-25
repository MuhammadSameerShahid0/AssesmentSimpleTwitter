using SimpleTwitter.DTOs.TwitterPost;

namespace SimpleTwitter.Services.TwitterPostServices
{
    public interface ITwitterPostService
    {
        Task AddTwitterPostAsync(TwitterPostDto postDto, Guid userId);
        Task<IEnumerable<TwitterPostDto>> GetAllPostsAsync();  // Fetch all posts

    }
}
