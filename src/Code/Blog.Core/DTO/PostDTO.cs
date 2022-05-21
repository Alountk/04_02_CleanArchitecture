using Blog.Core.Entities;

namespace Blog.Core.DTO
{
    public class PostDTO
    {
        public PostDTO()
        {
            PostComments = new HashSet<PostCommentDTO>();
            PostMeta = new HashSet<PostMetaDTO>();
        }

        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? Content { get; set; }

        // public virtual User Author { get; set; } = null!;
        public virtual ICollection<PostCommentDTO> PostComments { get; set; }
        public virtual ICollection<PostMetaDTO> PostMeta { get; set; }
    }
}