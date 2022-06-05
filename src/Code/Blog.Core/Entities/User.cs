namespace Blog.Core.Entities
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        // public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        // public DateTime TokenCreated { get; set; }
        // public DateTime TokenExpires { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
