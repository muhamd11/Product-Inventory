using App.Shared.Models.ProductModule;
using App.Shared.Models.ProductModule.Contracts.DTO;
using App.Shared.Models.ProductModule.ViewModel;
using AutoMapper;

namespace Api.MappingProfiles.ProductProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, AddProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, ProductInfoDetails>().ReverseMap();
            CreateMap<Product, ProductInfo>().ReverseMap();

        }
    }

}
