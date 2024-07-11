using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.Products;

namespace App.Shared.Models.ProductStores
{
    public class ProductStoreInfoDetails
    {
        public int productStoreId { get; set; }
        public Product productData { get; set; }
        public Unit unitData { get; set; }
        public Color colorData { get; set; }
        public int quantity { get; set; }
    }
}