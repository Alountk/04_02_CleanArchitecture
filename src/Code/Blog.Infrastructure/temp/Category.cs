using System;
using System.Collections.Generic;

namespace Blog.Infrastructure.temp
{
    public partial class Category
    {
        public Category()
        {
            PostCategories = new HashSet<PostCategory>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Slug { get; set; } = null!;
        public string? Content { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}
