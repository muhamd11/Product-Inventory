using System;
using App.Shared.Models.PlacesModules.Stores;

namespace App.Shared.Models.PlacesModules.Stores.DTO
{
    public class StoreAddOrUpdateDTO
    {
        public int storeId { get; set; }
        public StoreContactInfo storeContactInfo { get; set; }
        public StoreContactSocialMedia storeContactSocialMedia { get; set; }
        public TimeSpan storeOpenAt { get; set; }
        public TimeSpan storeCloseAt { get; set; }
    }
}