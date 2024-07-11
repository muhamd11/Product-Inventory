using App.Shared.Models.PlacesModules.Branches.DTO;
using App.Shared.Models.PlacesModules.Branches;
using AutoMapper;
using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.PlacesModules.Stores.DTO;

namespace Api.MappingProfiles.ProductsModules
{
    public class PlacesModulesProfile : Profile
    {
        public PlacesModulesProfile()
        {
            CreateMap<Branch, BranchAddOrUpdateDTO>().ReverseMap();
            CreateMap<Store, StoreAddOrUpdateDTO>().ReverseMap();
        }
    }
}
