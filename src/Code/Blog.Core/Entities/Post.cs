using Blog.Core.Entities.Base;

namespace Blog.Core.Entities
{
    public partial class Post : EntityBase<Guid>
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
            PostMeta = new HashSet<PostMeta>();
        }
        public Guid AuthorId { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? Content { get; set; }

        // public virtual User Author { get; set; } = null!;
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostMeta> PostMeta { get; set; }
    }
}
