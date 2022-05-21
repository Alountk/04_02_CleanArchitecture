namespace Blog.Core.Interfaces.Management
{
    public interface IUpdateEntity<TKey> : IAddEntity<TKey>
    {
        public DateTime? UpdatedAt { get; set; }
        public int? AccountIdUpdateDate { get; set; }
    }
}