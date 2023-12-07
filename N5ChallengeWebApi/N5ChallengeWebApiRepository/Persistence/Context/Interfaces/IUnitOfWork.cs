using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;

namespace N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces
{
    public interface IUnitOfWork
    {
        IPermissionRepository GetPermissionRepository();
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
