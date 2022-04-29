namespace Blog.Core.Entities
{
    public class Categories
    {
        public Guid id { get; set; }
        public Guid parent_id { get; set; }
        public string title { get; set; }
        public string meta_title { get; set; }
        public string slug { get; set; }
        public string content { get; set; }
    }
}