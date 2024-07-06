using App.Shared.Models.Products;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.Shared.Models.AdditionsModules.CategoryModule.ViewModel
{
    public class CategoryInfoDetails : CategoryInfo
    {
        [JsonPropertyOrder(3)]
        public string categoryDescription { get; set; }

        [JsonPropertyOrder(4)]
        public ICollection<ProductInfoDetails> productsData { get; set; }
    }
}