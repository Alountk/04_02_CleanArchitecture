using Blog.Core.Entities.Base;

namespace Blog.Core.Entities
{
    public partial class User : EntityBase<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
