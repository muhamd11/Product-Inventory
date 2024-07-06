using App.Shared.Models.ProductStores;
using App.Shared.Models.ProductStores.DTO;
using AutoMapper;

namespace Api.MappingProfiles.ProductProducts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductStore, ProductStoreAddOrUpdateDTO>().ReverseMap();
        }
    }
}