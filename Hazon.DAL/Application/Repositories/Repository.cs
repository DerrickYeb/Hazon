using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hazon.DAL.Domain.Data;
using Hazon.DAL.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hazon.DAL.Application.Repositories
{
    public class Repository:IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
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

        public async Task<T> RemoveByIdAsync<T>(Guid id) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<T> RemoveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
