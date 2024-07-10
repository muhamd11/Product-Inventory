using App.Shared.Models.Users;
using AutoMapper;

namespace Api.MappingProfiles.Users
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserAddOrUpdateDTO>().ReverseMap();
        }
    }
}