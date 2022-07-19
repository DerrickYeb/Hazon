using System.Linq.Expressions;
using Core.Application.Repositories;
using Core.Domain.Contracts;
using Core.Domain.Models.SetupModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class Repository<T>:IRepository<T>
    {
        private readonly ApplicationDbContext _context;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity
        {
            return (await _context.Set<T>().FindAsync(id))!;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> GetCountAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            return _context.Set<T>().Count();
        }

        public async Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync(cancellationToken: cancellationToken);
        }

        public Task<IAsyncEnumerable<T1>> GetListByYield<T1>() where T1 : BaseEntity
        {
            return  Task.FromResult((_context.Set<T1>().AsEnumerable() as IAsyncEnumerable<T1>)!);
            
        }

        public async Task<T> CreateAsync<T>(T entity) where T : BaseEntity
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public async Task<T> ExistAsync<T>(Expression<Func<T, bool>> expression, CancellationToken token = default) where T : BaseEntity
        {
            return (await _context.Set<T>().FindAsync(expression))!;
        }

        public Task<T> UpdateAsync<T>(T entity) where T : BaseEntity
        {
            var result = _context.Set<T>().Update(entity);
            return Task.FromResult(result.Entity);
        }

        public async Task<bool> RemoveByIdAsync<T>(Guid id) where T : BaseEntity
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return _context.Set<T>().Remove(entity!).State == EntityState.Deleted;
        }

        public Task<T1> RemoveAsync<T1>(T1 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<T1> UpdateAsync<T1>(PolicyType newDescription)
        {
            throw new NotImplementedException();
        }

        // public Task<T> RemoveAsync<T>(T entity) where T : class
        // {
        //     return _context.Set<T>().Remove(entity);
        // }
    }
}
