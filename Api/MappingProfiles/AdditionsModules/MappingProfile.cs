using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Colors.DTO;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.AdditionsModules.Shared.Units.DTO;
using App.Shared.Models.UsersModule.LogActionsModel;
using App.Shared.Models.UsersModule.LogActionsModel.DTO;
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