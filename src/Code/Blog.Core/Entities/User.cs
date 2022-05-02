using System;
using System.Collections.Generic;

namespace Blog.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
