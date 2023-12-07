using N5ChallengeWebApiDomain.Entities;
namespace N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> AddAsync(T item);
        Task<T> Update(T item);
    }
}
