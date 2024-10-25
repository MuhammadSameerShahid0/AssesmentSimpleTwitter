using SimpleTwitter.Models;

namespace SimpleTwitter.Interfaces.Comments
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsByTwitterIdAsync(Guid twitterId);
    }
}
