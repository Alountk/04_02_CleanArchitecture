namespace Blog.Domain.ValueObjects
{
    public record PostId
    {
        public Guid Value { get; }
        public PostId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPostException();
            }
            Value = value;
        }
        public static implicit operator Guid(PostId id) => id.Value;
        public static implicit operator PostId(Guid value) => new PostId(value);
    }
}