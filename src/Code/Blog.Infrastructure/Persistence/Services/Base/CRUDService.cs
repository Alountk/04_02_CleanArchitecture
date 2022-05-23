using Microsoft.EntityFrameworkCore;

using Ardalis.GuardClauses;

using Blog.Core.Interfaces.Base;
using Blog.Core.Interfaces.Management;
using Blog.Core.Interfaces.Services.Base;

namespace Blog.Infrastructure.Persistence.Services.Base
{
    public class CRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext> :
                ICRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext>
                where TEntity : class, IEntityBase<TKey>
                where TRepoAll : IBaseRepository<TEntity, TContext>
                where TContext : DbContext, new()
    {
        internal readonly TRepoAll _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;
        protected TRepoAll Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public CRUDService(TRepoAll repository, IUnitOfWork<TContext> unitOfWork)
        {
            _unitOfWork = Guard.Against.Null(UnitOfWork, nameof(UnitOfWork));
            _repository = Guard.Against.Null(Repository, nameof(repository));
        }
    }
}