using AutoMapper;

namespace Api.MappingProfiles.UnitProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Color, ColorAddOrUpdateDTO>().ReverseMap();
            CreateMap<Unit, UnitAddOrUpdateDTO>().ReverseMap();
            CreateMap<LogAction, LogActionAddOrUpdateDTO>().ReverseMap();
        }
    }
}