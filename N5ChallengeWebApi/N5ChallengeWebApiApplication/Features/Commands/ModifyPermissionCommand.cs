using AutoMapper;
using MediatR;
using N5ChallengeWebApiApplication.DTOs;
using N5ChallengeWebApiDomain.Entities;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
namespace N5ChallengeWebApiApplication.Features.Commands
{
    public class ModifyPermissionCommand : IRequest<int>
    {
        public required ModifyPermission ModifyPermission { get; set; }
    }
    public class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IElasticSearchRepository _elasticSearchRepository;
        public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IElasticSearchRepository elasticSearchRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _elasticSearchRepository = elasticSearchRepository;
        }
        public async Task<int> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionRepository = _unitOfWork.GetRepository<Permission>();
            var permission = _mapper.Map<Permission>(request.ModifyPermission);
            await permissionRepository.Update(permission);
            var saved = await _unitOfWork.SaveChangesAsync();
            await _elasticSearchRepository.UpdateAsync(_mapper.Map<N5ChallengeWebApiDomain.Entities.ElasticSearch.Permission>(permission));
            return saved;
        }
    }   
}
