namespace SimpleTwitter.DTOs.Comment
{
    public class CreateCommentDto
    {
        public Guid TwitterId { get; set; }
        public string Username { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
