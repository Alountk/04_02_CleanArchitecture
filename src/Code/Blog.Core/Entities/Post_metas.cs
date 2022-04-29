namespace Blog.Core.Entities
{
    public class Post_metas
    {
        public Guid id { get; set; }
        public Guid post_id { get; set; }
        public string meta_key { get; set; }
        public string meta_value { get; set; }
    }
}