namespace SimpleTwitter.Models
{
    public class TwitterPost
    {
        public Guid TwitterId { get; set; }
        public Guid UserId { get; set; }  // Foreign key
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;  // The content of the post
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation property
        public User User { get; set; }
    }

}
