namespace SimpleTwitter.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; }= null!;
        public byte[] PasswordSalt { get; set; } = null!;

        // Navigation property for posts
        public ICollection<TwitterPost> TwitterPosts { get; set; }
    }

}
