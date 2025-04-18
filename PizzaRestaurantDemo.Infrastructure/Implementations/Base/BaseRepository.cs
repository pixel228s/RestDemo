using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.Persistence.Data;

namespace PizzaRestaurantDemo.Infrastructure.Implementations.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly PizzaRestaurantDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(PizzaRestaurantDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetAsync(CancellationToken cancellationToken, params object[] key)
        {
            return await _dbSet.FindAsync(key, cancellationToken);
        }

        public async Task AddAsync(CancellationToken cancellationToken, T entity)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(CancellationToken cancellationToken, T entity)
        {
            if (entity == null)
            {
                return;
            }

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateEntity(CancellationToken cancellationToken, T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
