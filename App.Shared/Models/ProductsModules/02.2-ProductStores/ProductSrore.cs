using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.ProductStores
{
    public class ProductStore
    {
        public int productStoreId { get; set; }

        [ForeignKey(nameof(productData))]
        public int productId { get; set; }

        public Product productData { get; set; }

        [ForeignKey(nameof(unitData))]
        public int unitId { get; set; }

        public Unit unitData { get; set; }

        [ForeignKey(nameof(colorData))]
        public int colorId { get; set; }

        public Color colorData { get; set; }

        public int quantity { get; set; }
    }
}