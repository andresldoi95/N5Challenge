using AutoMapper;
using N5ChallengeWebApiApplication.DTOs;
using N5ChallengeWebApiDomain.Entities;
namespace N5ChallengeWebApiApplication.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RequestPermission, Permission>();
            CreateMap<Permission, RequestedPermission>();
            CreateMap<Permission, PermissionView>();
            CreateMap<ModifyPermission, Permission>();
        }
    }
}
