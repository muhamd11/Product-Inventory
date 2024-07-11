using App.Shared.Models.Products;
using System.Linq.Expressions;

namespace Api.Controllers.ProductsModules.Products.Services
{
    public static class ProductAdaptor
    {
        public static Expression<Func<Product, ProductInfo>> SelectExpressionProductInfo()
        {
            return product => new ProductInfo
            {
                productId = product.productId,
                productName = product.productName,
            };
        }

        public static Expression<Func<Product, ProductInfoDetails>> SelectExpressionProductDetails()
        {
            return product => new ProductInfoDetails
            {
                productId = product.productId,
                productName = product.productName,
                productDescription = product.productDescription,
            };
        }

        public static ProductInfo SelectExpressionProductInfo(Product product)
        {
            return new ProductInfo
            {
                productId = product.productId,
                productName = product.productName,
            };
        }

        public static ProductInfoDetails SelectExpressionProductDetails(Product product)
        {
            return new ProductInfoDetails
            {
                productId = product.productId,
                productName = product.productName,
                productDescription = product.productDescription
            };
        }
    }
}