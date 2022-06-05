namespace Blog.Core.DTO
{
    public class PostUpdateDTO
    {
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public string? Content { get; set; }
    }
}