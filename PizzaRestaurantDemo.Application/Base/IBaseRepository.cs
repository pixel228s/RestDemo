namespace PizzaRestaurantDemo.Infrastructure
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAsync(CancellationToken cancellationToken, params object[] key);
        Task AddAsync(CancellationToken cancellationToken, T entity);
        Task RemoveAsync(CancellationToken cancellationToken, T entity);
        Task UpdateEntity(CancellationToken cancellationToken, T entity);
    }
}
