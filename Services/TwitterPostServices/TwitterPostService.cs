using SimpleTwitter.DTOs.TwitterPost;
using SimpleTwitter.Interfaces.Twitter;
using SimpleTwitter.Models;

namespace SimpleTwitter.Services.TwitterPostServices
{
    public class TwitterPostService : ITwitterPostService
    {
        private readonly ITwitterPostRepository _twitterPostRepository;

        public TwitterPostService(ITwitterPostRepository twitterPostRepository)
        {
            _twitterPostRepository = twitterPostRepository;
        }

        // Method to add a new Twitter post for a specific user
        public async Task AddTwitterPostAsync(TwitterPostDto postDto, Guid userId)
        {
            var newPost = new TwitterPost
            {
                TwitterId = Guid.NewGuid(),
                UserId = userId,
                Title = postDto.Title,
                Description = postDto.Description
            };

            await _twitterPostRepository.AddTwitterPostAsync(newPost);
        }

        public async Task<IEnumerable<TwitterPostDto>> GetAllPostsAsync()
        {
            var posts = await _twitterPostRepository.GetAllPostsAsync();
            return posts.Select(p => new TwitterPostDto
            {
                Title = p.Title,
                Description = p.Description,
            });
        }

    }
}
