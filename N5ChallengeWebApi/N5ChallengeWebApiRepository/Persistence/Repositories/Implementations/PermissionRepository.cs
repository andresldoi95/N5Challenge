using Microsoft.EntityFrameworkCore;
using N5ChallengeWebApiDomain;
using N5ChallengeWebApiDomain.Entities;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
namespace N5ChallengeWebApiInfrastructure.Persistence.Repositories.Implementations
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly N5ChallengeDBContext _context;
        private readonly DbSet<Permission> _dbSet;

        public PermissionRepository(N5ChallengeDBContext context) {
            _context = context;
            _dbSet = _context.Set<Permission>();
        }
        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _dbSet.Include(p => p.PermissionType).AsNoTracking().ToListAsync();
        }
        public async Task<Permission> AddAsync(Permission permission)
        {
            var result = await _dbSet.AddAsync(permission);
            return result.Entity;
        }
        public async Task<Permission> Update(Permission permission)
        {
            var result = _dbSet.Update(permission);
            return result.Entity;
        }
    }
}
