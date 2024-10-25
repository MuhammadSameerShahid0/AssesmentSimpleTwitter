using SimpleTwitter.DTOs.Comment;

namespace SimpleTwitter.Services.CommentServices
{
    public interface ICommentService
    {
        Task AddCommentAsync(CreateCommentDto createCommentDto, string loggedInUsername);
        Task<IEnumerable<CommentDto>> GetCommentsByTwitterIdAsync(Guid twitterId);
    }
}
