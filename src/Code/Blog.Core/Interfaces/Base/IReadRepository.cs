using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Interfaces.Base
{
    public interface IReadRepository<T, TContext> where T : class where TContext : DbContext, new()
    {
        Task<List<T>> AllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(CancellationToken cancellationToken = default);
        Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}