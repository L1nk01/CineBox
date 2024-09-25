using Application.Repository.Interfaces;
using Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.Common
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _dbContext;
        private readonly string _entityName;

        public GenericRepository(ApplicationContext dbContext, string entityName)
        {
            _dbContext = dbContext;
            _entityName = entityName;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{this._entityName} with ID {id} not found.");
            }
            return entity;
        }
    }
}
