using System.Linq.Expressions;
using Core.Application.Services;
using Core.Domain.Contracts;

namespace Core.Application.Repositories
{
    public interface IRepository<T>:ITransient
    {
        public Task<T> GetByIdAsync<T>(Guid id)where T : BaseEntity;
        public Task<IEnumerable<T>> GetAllAsync<T>()
        where T : BaseEntity;
        Task<int> GetCountAsync<T>(Expression<Func<T,bool>> predicate = null,CancellationToken cancellationToken = default) where T : BaseEntity;

        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> expression,
            CancellationToken cancellationToken = default) where T : BaseEntity;

        Task<IAsyncEnumerable<T>> GetListByYield<T>() where T : BaseEntity;
        Task<T> CreateAsync<T>(T entity) where
            T:BaseEntity;

        Task<T> ExistAsync<T>(Expression<Func<T, bool>> expression, CancellationToken token = default)
            where T : BaseEntity;

        Task<T> UpdateAsync<T>(T entity)where T:BaseEntity;
        Task<bool> RemoveByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<T> RemoveAsync<T>(T entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    
}
