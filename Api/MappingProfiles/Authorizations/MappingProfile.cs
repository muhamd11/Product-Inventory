using App.Shared.Models.Roles;
using AutoMapper;

namespace Api.MappingProfiles.Authorizations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleAddOrUpdateDTO>().ReverseMap();
        }
    }
}