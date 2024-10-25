namespace SimpleTwitter.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TwitterId { get; set; }  // Foreign key to TwitterPost
        public string Username { get; set; } = null!;
        public string Content { get; set; } = null!;  // The comment text
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
