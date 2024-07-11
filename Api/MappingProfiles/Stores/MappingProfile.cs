using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.PlacesModules.Stores.DTO;
using AutoMapper;

namespace Api.MappingProfiles.Stores
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreAddOrUpdateDTO>().ReverseMap();
        }
    }
}