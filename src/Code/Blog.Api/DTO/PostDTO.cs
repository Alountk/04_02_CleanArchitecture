namespace Blog.Api.DTO
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string? Content { get; set; }
    }
}