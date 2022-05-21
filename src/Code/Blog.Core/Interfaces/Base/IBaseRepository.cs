using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Interfaces.Base
{
    public interface IBaseRepository<T, TContext> : IReadRepository<T, TContext> where T : class where TContext : DbContext, new()
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
    }
}