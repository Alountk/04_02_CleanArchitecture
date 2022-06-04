namespace Blog.Core.DTO
{
    public class UserUpdateDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
    }
}