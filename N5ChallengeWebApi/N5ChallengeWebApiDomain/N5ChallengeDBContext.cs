using Microsoft.EntityFrameworkCore;
using N5ChallengeWebApiDomain.Entities;

namespace N5ChallengeWebApiDomain
{
    public class N5ChallengeDBContext : DbContext
    {
        public N5ChallengeDBContext(DbContextOptions<N5ChallengeDBContext> options) : base(options) { }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
