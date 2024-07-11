using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Models.UsersModule.LogActionsModel;
using App.Shared.Models.UsersModule.LogActionsModel.DTO;
using AutoMapper;

namespace Api.MappingProfiles.Authorizations
{
    public class SystemBaseProfile : Profile
    {
        public SystemBaseProfile()
        {
            CreateMap<SystemRole, RoleAddOrUpdateDTO>().ReverseMap();
            CreateMap<LogAction, LogActionAddOrUpdateDTO>().ReverseMap();
        }
    }
}