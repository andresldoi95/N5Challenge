using AutoMapper;
using MediatR;
using N5ChallengeWebApiApplication.DTOs;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
namespace N5ChallengeWebApiApplication.Features.Queries
{
    public class GetAllPermissionsQuery : IRequest<IEnumerable<PermissionView>>{}
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, IEnumerable<PermissionView>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionView>> Handle(GetAllPermissionsQuery request, CancellationToken cancellation)
        {
            var permissions = await _unitOfWork.GetPermissionRepository().GetAll();
            return _mapper.Map<IEnumerable<PermissionView>>(permissions);
        }
    }
}
