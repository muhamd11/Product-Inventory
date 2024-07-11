using App.Shared.Models.PlacesModules.Branches.DTO;
using App.Shared.Models.PlacesModules.Branches;
using AutoMapper;
using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.PlacesModules.Stores.DTO;
using App.Shared.Models.Products.DTO;
using App.Shared.Models.Products;
using App.Shared.Models.ProductStores.DTO;
using App.Shared.Models.ProductStores;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductsModules.Categories.DTO;

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
