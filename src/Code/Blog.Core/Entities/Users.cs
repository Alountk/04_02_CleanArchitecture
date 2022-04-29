namespace Blog.Core.Entities
{
    public class Users
    {
        public Guid id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public bool is_admin { get; set; }
        public bool is_active { get; set; }
        public DateTime registered_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime last_login { get; set; }
    }
}