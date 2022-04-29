namespace Blog.Core.Entities
{
    public class Post_Comments
    {
        public Guid id { get; set; }
        public Guid post_id { get; set; }
        public Guid parent_id { get; set; }
        public string title { get; set; }
        public bool published { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public string content { get; set; }
    }
}