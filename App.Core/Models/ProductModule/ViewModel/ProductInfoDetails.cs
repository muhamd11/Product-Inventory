using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Shared.Models.ProductModule.ViewModel
{
    public class ProductInfoDetails : ProductInfo
    {
        [JsonPropertyOrder(3)]
        public string productDescription { get; set; }

        [JsonPropertyOrder(4)]
        public ICollection<ProductStoreInfo> productStoreInfoData { get; set; }

    }
}
