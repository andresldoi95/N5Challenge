using AutoMapper;
using MediatR;
using N5ChallengeWebApiApplication.DTOs;
using N5ChallengeWebApiDomain.Entities;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
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
        public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionRepository = _unitOfWork.GetRepository<Permission>();
            var permission = _mapper.Map<Permission>(request.ModifyPermission);
            await permissionRepository.Update(permission);
            return await _unitOfWork.SaveChangesAsync();
        }
    }   
}
