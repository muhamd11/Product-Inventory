using System;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Stores
{
    public class StoreInfoDetails : StoreInfo
    {
        [JsonPropertyOrder(3)]
        public StoreContactSocialMedia storeContactSocialMedia { get; set; }

        [JsonPropertyOrder(4)]
        public TimeSpan storeOpenAt { get; set; }

        [JsonPropertyOrder(5)]
        public TimeSpan storeCloseAt { get; set; }
    }
}