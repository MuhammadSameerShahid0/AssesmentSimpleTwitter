using SimpleTwitter.DTOs.Comment;
using SimpleTwitter.Interfaces.Comments;
using SimpleTwitter.Interfaces.Twitter;
using SimpleTwitter.Models;

namespace SimpleTwitter.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITwitterPostRepository _twitterPostRepository;

        public CommentService(ICommentRepository commentRepository, ITwitterPostRepository twitterPostRepository)
        {
            _commentRepository = commentRepository;
            _twitterPostRepository = twitterPostRepository;
        }

        public async Task AddCommentAsync(CreateCommentDto createCommentDto, string loggedInUsername)
        {
            // Check if the TwitterPost exists
            var twitterPost = await _twitterPostRepository.GetTwitterPostByIdAsync(createCommentDto.TwitterId);
            if (twitterPost == null)
            {
               throw new Exception("Twitter post not found.");
            }

            if (createCommentDto.Username != loggedInUsername)
                throw new UnauthorizedAccessException("Username does not match the logged-in user.");

            if (createCommentDto.Content.Length > 140)
                throw new ArgumentException("Comment cannot exceed 140 characters.");

            var comment = new Comment
            {
                TwitterId = createCommentDto.TwitterId,
                Username = createCommentDto.Username,
                Content = createCommentDto.Content,
            };

            await _commentRepository.AddCommentAsync(comment);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByTwitterIdAsync(Guid twitterId)
        {
            var comments = await _commentRepository.GetCommentsByTwitterIdAsync(twitterId);
            return comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Username = c.Username,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            });
        }
    }
}
