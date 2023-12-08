using N5ChallengeWebApiDomain.Entities.ElasticSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces
{
    public interface IElasticSearchRepository
    {
        Task AddAsync(Permission permission);
        Task UpdateAsync(Permission permission);
    }
}
