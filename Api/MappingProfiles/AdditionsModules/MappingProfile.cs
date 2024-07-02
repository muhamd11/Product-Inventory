using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.ColorModule.DTO;
using App.Shared.Models.AdditionsModules.UnitModule;
using App.Shared.Models.AdditionsModules.UnitModule.DTO;
using AutoMapper;

namespace Api.MappingProfiles.UnitProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Color, ColorAddOrUpdateDTO>().ReverseMap();
            CreateMap<Unit, UnitAddOrUpdateDTO>().ReverseMap();
        }
    }
}