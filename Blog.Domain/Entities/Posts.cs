namespace Blog.Domain.Entities
{
    public class Posts
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid UserId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid? ImageId { get; private set; }
        public Guid? VideoId { get; private set; }
        public Guid? AudioId { get; private set; }
        public Guid? DocumentId { get; private set; }
        public List<Comments> Comments { get; private set; }
    }
}