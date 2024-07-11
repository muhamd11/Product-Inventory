using System;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    public class BuyerInfoDetails : BuyerInfo
    {
        [JsonPropertyOrder(3)]
        public string buyerCountryCodeName { get; set; }
        [JsonPropertyOrder(4)]
        public string buyerCountryCode { get; set; }
        [JsonPropertyOrder(5)]
        public string buyerDailCode { get; set; }
        [JsonPropertyOrder(6)]
        public string buyerPhoneNumber { get; set; }
        [JsonPropertyOrder(7)]
        public string buyerEmail { get; set; }
        [JsonPropertyOrder(8)]
        public DateOnly buyerBirthDate { get; set; }
        [JsonPropertyOrder(9)]
        public bool buyerIsActive { get; set; }
    }
}