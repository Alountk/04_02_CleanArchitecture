using System;
using System.Collections.Generic;

namespace Blog.Core.DTO
{
    public partial class PostMetaDTO
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string MetaKey { get; set; } = null!;
        public string? MetaValue { get; set; }

        public virtual PostDTO Post { get; set; } = null!;
    }
}
