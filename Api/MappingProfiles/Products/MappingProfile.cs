using App.Shared.Models.Products;
using App.Shared.Models.Products.DTO;
using AutoMapper;

namespace Api.MappingProfiles.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductAddOrUpdateDTO>().ReverseMap();
        }
    }
}