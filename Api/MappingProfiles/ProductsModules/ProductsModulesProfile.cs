using App.Shared.Models.Products;
using App.Shared.Models.Products.DTO;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductsModules.Categories.DTO;
using App.Shared.Models.ProductStores;
using App.Shared.Models.ProductStores.DTO;
using AutoMapper;

namespace Api.MappingProfiles.ProductsModules
{
    public class ProductsModulesProfile : Profile
    {
        public ProductsModulesProfile()
        {
            CreateMap<Category, CategoryAddOrUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductAddOrUpdateDTO>().ReverseMap();
            CreateMap<ProductStore, ProductStoreAddOrUpdateDTO>().ReverseMap();

        }
    }
}
