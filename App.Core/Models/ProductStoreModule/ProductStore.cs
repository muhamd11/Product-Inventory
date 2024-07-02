

using App.Core.Models.UnitModule;
using App.Shared.Models.ColorModule;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.ProductModule
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

    }
}
