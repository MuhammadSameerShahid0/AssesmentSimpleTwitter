using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleTwitter.DTOs.TwitterPost;
using SimpleTwitter.Interfaces.Twitter;
using SimpleTwitter.Models;
using SimpleTwitter.Services.TwitterPostServices;
using System.Security.Claims;

namespace SimpleTwitter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwitterPostController : ControllerBase
    {
        private readonly ITwitterPostRepository _twitterPostRepository;
        private readonly ITwitterPostService _twitterPostService;

        public TwitterPostController(ITwitterPostRepository twitterPostRepository, ITwitterPostService twitterPostService)
        {
            _twitterPostRepository = twitterPostRepository;
            _twitterPostService = twitterPostService;
        }

        // Create a new post for the logged-in user (requires authentication)
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(TwitterPostDto twitterPostDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized("User is not authenticated.");
                }

                Guid userId = Guid.Parse(userIdClaim);

                var newPost = new TwitterPost
                {
                    TwitterId = Guid.NewGuid(),
                    UserId = userId,
                    Title = twitterPostDto.Title,
                    Description = twitterPostDto.Description,
                    CreatedAt = DateTime.UtcNow
                };

                await _twitterPostRepository.AddTwitterPostAsync(newPost);
                return Ok("Post created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all posts (does not require authentication)
        [HttpGet("all-posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var allPosts = await _twitterPostService.GetAllPostsAsync();
                return Ok(allPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
