using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Blog.Core.Interfaces.Base;
using Blog.Core.Interfaces.Management;

namespace Blog.Core.Interfaces.Services.Base
{
    public interface ICRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<List<TGetDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TGetDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<List<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TAddDto> AddAsync(TAddDto dto, CancellationToken cancellationToken = default);
        Task<TUpdDto> UpdateAsync(TUpdDto dto, CancellationToken cancellationToken = default);
        Task<TDelDto> DeleteAsync(TDelDto dto, CancellationToken cancellationToken = default);
    }
}