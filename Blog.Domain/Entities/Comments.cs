namespace Blog.Domain.Entities
{
    public class Comments
    {
        public Guid Id { get; set; }
        private string _text;
        private DateTime _createdAt;
        private DateTime _updatedAt;
        internal Comments(Guid id, string text, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            _text = text;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }
    }
}