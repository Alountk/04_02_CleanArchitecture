namespace Blog.Shared.Abstractions.Domain
{
    public public interface IDomainEvent
    {
        public Guid Id { get; }
        public int Version { get; }
    }
}