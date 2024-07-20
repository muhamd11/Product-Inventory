using App.Shared.Consts.SystemBase;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.PlacesModules.Stores
{
    [Table($"{nameof(Store)}s", Schema = nameof(EnumDatabaseSchema.Places))]
    public class Store
    {
        public int storeId { get; set; }
        public StoreContactInfo storeContactInfo { get; set; }
        public StoreContactSocialMedia storeContactSocialMedia { get; set; }
        public TimeSpan storeOpenAt { get; set; }
        public TimeSpan storeCloseAt { get; set; }
    }

    [Owned]
    public class StoreContactSocialMedia
    {
        [JsonIgnore] public bool jsutForBuildEF { get; set; }
        public string storeWebsite { get; set; }
        public string facebookLink { get; set; }
        public string twitterLink { get; set; }
        public string instagramLink { get; set; }
        public string linkedinLink { get; set; }
        public string youtubeLink { get; set; }
    }

    [Owned]
    public class StoreContactInfo
    {
        [JsonIgnore] public bool jsutForBuildEF { get; set; }
        public string storeName { get; set; }
        public string storeAddress { get; set; }
        public double storeLatitude { get; set; }
        public double storeLongitude { get; set; }
        public string storeManagerName { get; set; }
        public string storeEmail { get; set; }
        public string storeCountryCodeName { get; set; }
        public string storeCountryCode { get; set; }
        public string storeDailCode { get; set; }
        public string storePhoneNumber { get; set; }
    }
}