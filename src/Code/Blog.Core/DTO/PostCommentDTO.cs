namespace Blog.Core.DTO
{
    public class PostCommentDTO
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PostId { get; set; }
        public string Title { get; set; } = null!;
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? Content { get; set; }
    }
}