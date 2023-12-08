using AutoMapper;
using MediatR;
using N5ChallengeWebApiApplication.DTOs;
using N5ChallengeWebApiDomain.Entities;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
namespace N5ChallengeWebApiApplication.Features.Commands
{
    public class RequestPermissionCommand : IRequest<RequestedPermission>
    {
        public required RequestPermission Permission { get; set; }
    }
    public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, RequestedPermission>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IElasticSearchRepository _elasticSearchRepository;

        public RequestPermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IElasticSearchRepository elasticSearchRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _elasticSearchRepository = elasticSearchRepository;
        }

        public async Task<RequestedPermission> Handle(RequestPermissionCommand command, CancellationToken cancellation)
        {
            var permissionRepository = _unitOfWork.GetRepository<Permission>();
            var permission = _mapper.Map<Permission>(command.Permission);
            var requestedPermission = await permissionRepository.AddAsync(permission);
            await _unitOfWork.SaveChangesAsync();
            await _elasticSearchRepository.AddAsync(_mapper.Map<N5ChallengeWebApiDomain.Entities.ElasticSearch.Permission>(requestedPermission));
            return _mapper.Map<RequestedPermission>(requestedPermission);
        }
    }
}
