using App.Shared.Models.ProductStores;
using System.Collections.Generic;

namespace App.Shared.Models.AdditionsModules.ColorModule
{
    public class Color
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