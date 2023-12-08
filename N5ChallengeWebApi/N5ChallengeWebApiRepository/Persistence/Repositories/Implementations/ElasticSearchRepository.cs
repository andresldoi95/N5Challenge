using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using N5ChallengeWebApiDomain.Entities.ElasticSearch;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
namespace N5ChallengeWebApiInfrastructure.Persistence.Repositories.Implementations
{
    public class ElasticSearchRepository : IElasticSearchRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ElasticsearchClient _elasticClient;
        private readonly string _indexName = "permissions";
        public ElasticSearchRepository(IConfiguration configuration) { 
            _configuration = configuration;
            _elasticClient = new ElasticsearchClient(_configuration["ElasticSearchCloudId"], new ApiKey(_configuration["ElasticSearchApiKey"]));
        }
        public async Task AddAsync(Permission permission)
        {
            await _elasticClient.IndexAsync(permission, _indexName);
        }

        public async Task UpdateAsync(Permission permission)
        {
            await _elasticClient.UpdateAsync<Permission, Permission>(_indexName, permission.Id, u => u.Doc(permission));
        }
    }
}
