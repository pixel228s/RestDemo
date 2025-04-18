using Microsoft.EntityFrameworkCore;
using PizzaRestaurantDemo.Application.Users.Interfaces;
using PizzaRestaurantDemo.Domain.Models;
using PizzaRestaurantDemo.Infrastructure.Implementations.Base;
using PizzaRestaurantDemo.Persistence.Data;

namespace PizzaRestaurantDemo.Infrastructure.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PizzaRestaurantDbContext _context) : base(_context)
        {
        }

        public Task<User> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var user = _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
            return user;
        }

        public Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = _dbSet
                .AsNoTracking()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return user;
        }

        public Task<User> GetUserInfoById(int id, CancellationToken cancellationToken)
        {
            var user = _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return user;
        }

        public Task<User> GetUserAddressInfoById(int id, CancellationToken cancellationToken)
        {
            var user = _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return user;
        }
    }
}
