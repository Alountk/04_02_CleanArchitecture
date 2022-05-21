namespace Blog.Core.Interfaces.Management
{
    public interface IDeleteEntity<TKey> : IAddEntity<TKey>
    {
        public bool isDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? AccountIdDeleteDate { get; set; }
    }
}