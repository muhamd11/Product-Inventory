using App.Shared.Models.ColorModule;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.ColorModule.Contracts.VM;
using App.Shared.Models.ColorModule.ViewModel;
using AutoMapper;

namespace Api.MappingProfiles.ColorModule
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Color, AddColorDTO>().ReverseMap();
            CreateMap<Color, UpdateColorDTO>().ReverseMap();
            CreateMap<Color, ColorGetAllResponse>().ReverseMap();
            CreateMap<Color, ColorInfo>().ReverseMap();
        }
    }
}