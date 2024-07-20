using System.Text.Json.Serialization;

namespace App.Shared.Models.SystemBase.BaseClass
{
    public class BaseEntityInfo
    {
        [JsonPropertyOrder(1)]
        public bool isDeleted { get; set; }

        [JsonPropertyOrder(2)]
        public string createdDateTime { get; set; }

        [JsonPropertyOrder(2)]
        public string updatedDateTime { get; set; }
    }
}