using System.Text.Json.Serialization;

namespace App.Shared.Models.Stores
{
    public class StoreInfoDetails : StoreInfo
    {
        [JsonPropertyOrder(3)]
        public string storeAddress { get; set; }
    }
}