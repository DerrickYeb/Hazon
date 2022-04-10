using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hazon.DAL.Domain.Models;

namespace Hazon.DAL.Application.Repositories
{
    public interface IRepository
    {
        public Task<T> GetByIdAsync<T>(int id)where T : BaseEntity;
        public Task<T> GetAllAsync<T>()
        where T : BaseEntity;
        Task<int> GetCountAsync<T>(Expression<Func<T,bool>> predicate = null,CancellationToken cancellationToken = default) where T : BaseEntity;

        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> expression,
            CancellationToken cancellationToken = default) where T : BaseEntity;
        Task<T> CreateAsync<T>(T entity) where
            T:BaseEntity;

        Task<A> ExistAsync<A>(Expression<Func<A, bool>> expression, CancellationToken token = default)
            where A : BaseEntity;

        Task<T> UpdateAsync<T>(T entity)where T:BaseEntity;
        Task<T> RemoveByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<T> RemoveAsync<T>(T entity);
    }
}
