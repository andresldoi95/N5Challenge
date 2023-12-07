using AutoMapper;
using MediatR;
using N5ChallengeWebApiApplication.DTOs;
using N5ChallengeWebApiDomain.Entities;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
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

        public RequestPermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RequestedPermission> Handle(RequestPermissionCommand command, CancellationToken cancellation)
        {
            var permissionRepository = _unitOfWork.GetRepository<Permission>();
            var permission = _mapper.Map<Permission>(command.Permission);
            var requestedPermission = await permissionRepository.AddAsync(permission);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RequestedPermission>(requestedPermission);
        }
    }
}
