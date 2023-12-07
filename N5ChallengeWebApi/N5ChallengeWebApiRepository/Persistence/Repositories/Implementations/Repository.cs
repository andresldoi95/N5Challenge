using Microsoft.EntityFrameworkCore;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
namespace N5ChallengeWebApiInfrastructure.Persistence.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> AddAsync(T item)
        {
            var result = await _dbSet.AddAsync(item as T);
            return result.Entity;
        }

        public async Task<T> Update(T item)
        {
            var result = _dbSet.Update(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
