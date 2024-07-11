using App.Shared.Models.Products;

namespace App.Shared.Models.ProductStores
{
    public class ProductStoreInfo
    {
        public int productStoreId { get; set; }
        public ProductInfo productInfo { get; set; }
        public string colorName { get; set; }
        public string unitName { get; set; }
        public int quantity { get; set; }
    }
}