using App.Shared.Models.Users;
using AutoMapper;

namespace Api.MappingProfiles.Users
{
    public class UsersModulesProfile : Profile
    {
        public UsersModulesProfile()
        {
            CreateMap<BaseUser, BaseUserAddOrUpdateDTO>().ReverseMap();
        }
    }
}