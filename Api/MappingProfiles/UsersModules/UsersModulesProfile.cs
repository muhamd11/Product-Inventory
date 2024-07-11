using App.Shared.Models.Buyers;
using App.Shared.Models.Users;
using AutoMapper;

namespace Api.MappingProfiles.Users
{
    public class UsersModulesProfile : Profile
    {
        public UsersModulesProfile()
        {
            CreateMap<User, UserAddOrUpdateDTO>().ReverseMap();
         }
    }
}