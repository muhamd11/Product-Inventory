using Api.Controllers.AdditionsModules.Products.Services;
using App.Shared.Models.ProductStores;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.ProductProducts.Services
{
    public static class ProductStoresAdaptor
    {
        public static Expression<Func<ProductStore, ProductStoreInfo>> SelectExpressionProductStoreInfo()
        {
            return productStore => new ProductStoreInfo
            {
                productStoreId = productStore.productStoreId,
                productInfo = ProductAdaptor.SelectExpressionProductInfo(productStore.productData),
                unitName = productStore.unitData.unitName,
                colorName = productStore.colorData.colorName,
                quantity = productStore.quantity
            };
        }

        public static Expression<Func<ProductStore, ProductStoreInfoDetails>> SelectExpressionProductStoreDetails()
        {
            return productStore => new ProductStoreInfoDetails
            {
                productStoreId = productStore.productStoreId,
                productData = productStore.productData,
                unitData = productStore.unitData,
                colorData = productStore.colorData,
                quantity = productStore.quantity
            };
        }

        public static Expression<Func<ProductStore, ProductStoreInfo>> SelectExpressionProductStoreInfo(this ProductStore productStore)
        {
            return productStore => new ProductStoreInfo
            {
                productStoreId = productStore.productStoreId,
                productInfo = ProductAdaptor.SelectExpressionProductInfo(productStore.productData),
                unitName = productStore.unitData.unitName,
                colorName = productStore.colorData.colorName
            };
        }

        public static Expression<Func<ProductStore, ProductStoreInfoDetails>> SelectExpressionProductStoreDetails(this ProductStore productStore)
        {
            return productStore => new ProductStoreInfoDetails
            {
                productStoreId = productStore.productStoreId,
                productData = productStore.productData,
                unitData = productStore.unitData,
                colorData = productStore.colorData,
                quantity = productStore.quantity
            };
        }
    }
}