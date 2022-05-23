using System.Linq.Expressions;
using Blog.Core.Interfaces.Base;
using Blog.Core.Interfaces.Management;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Interfaces.Services.Base
{
    public interface IRService<TGetDto, TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<List<TGetDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TGetDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<List<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}