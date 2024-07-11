using App.Shared.Models.ProductStores;
using App.Shared.Models.SystemBase.BaseClass;
using System.Collections.Generic;

namespace App.Shared.Models.AdditionsModules.Shared.Colors
{
    public class Color : BaseEntity
    {
        public Color()
        {
            productStoreData = new HashSet<ProductStore>();
        }

        public int colorId { get; set; }
        public string colorName { get; set; }
        public string colorDescription { get; set; }
        public string colorHexCode { get; set; }
        public ICollection<ProductStore> productStoreData { get; set; }
    }
}