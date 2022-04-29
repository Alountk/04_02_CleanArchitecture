namespace Blog.Core.Entities
{
    public class Posts
    {
        public Guid id { get; set; }
        public Guid author_id { get; set; }
        public Guid parent_id { get; set; }
        public string title { get; set; }
        public string meta_title { get; set; }
        public string slug { get; set; }
        public string summary { get; set; }
        public bool published { get; set; }
        public bool deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime published_at { get; set; }
        public string content { get; set; }
    }
}