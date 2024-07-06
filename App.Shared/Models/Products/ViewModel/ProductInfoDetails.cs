using App.Shared.Models.AdditionsModules.CategoryModule;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Products
{
    public class ProductInfoDetails : ProductInfo
    {
        [JsonPropertyOrder(3)]
        public string productDescription { get; set; }

        [JsonPropertyOrder(4)]
        public ICollection<Category> categoriesData { get; set; }
    }
}