using SimpleTwitter.DatabaseContext;
using SimpleTwitter.Interfaces.Comments;
using SimpleTwitter.Models;

namespace SimpleTwitter.Repository.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTwitterIdAsync(Guid twitterId)
        {
            return _context.Comments
                .Where(c => c.TwitterId == twitterId)
                .OrderByDescending(c => c.CreatedAt);
        }
    }
}
