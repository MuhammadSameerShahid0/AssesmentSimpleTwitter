using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleTwitter.DTOs.Comment;
using SimpleTwitter.Services.CommentServices;
using System.Security.Claims;

namespace SimpleTwitter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            try
            {
                var loggedInUsername = User.FindFirst(ClaimTypes.Name)?.Value;
                if (loggedInUsername == null)
                {
                    return Unauthorized("User is not authenticated.");
                }

                await _commentService.AddCommentAsync(createCommentDto, loggedInUsername);
                return Ok("Comment created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{twitterId}/comments")]
        public async Task<IActionResult> GetCommentsByTwitterId(Guid twitterId)
        {
            try
            {
                var comments = await _commentService.GetCommentsByTwitterIdAsync(twitterId);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
