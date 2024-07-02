using App.Core.Models.UnitModule;
using App.Shared.Models.UnitModule.Contracts.DTO;
using App.Shared.Models.UnitModule.Contracts.VM;
using App.Shared.Models.UnitModule.ViewModel;
using AutoMapper;

namespace Api.MappingProfiles.UnitProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Unit, AddUnitDTO>().ReverseMap();
            CreateMap<Unit, UpdateUnitDTO>().ReverseMap();
            CreateMap<Unit, UnitGetAllResponse>().ReverseMap();
            CreateMap<Unit, UnitInfo>().ReverseMap();
        }
    }
}