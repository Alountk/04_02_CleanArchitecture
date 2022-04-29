using System;
using System.Collections.Generic;

namespace Blog.Infrastructure.temp
{
    public partial class PostComment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid ParentId { get; set; }
        public string Title { get; set; } = null!;
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? Content { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
