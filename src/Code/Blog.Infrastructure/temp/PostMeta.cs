using System;
using System.Collections.Generic;

namespace Blog.Infrastructure.temp
{
    public partial class PostMeta
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string MetaKey { get; set; } = null!;
        public string? MetaValue { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
