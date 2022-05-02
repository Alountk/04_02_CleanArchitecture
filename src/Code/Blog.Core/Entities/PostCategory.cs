using System;
using System.Collections.Generic;

namespace Blog.Core.Entities
{
    public partial class PostCategory
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
