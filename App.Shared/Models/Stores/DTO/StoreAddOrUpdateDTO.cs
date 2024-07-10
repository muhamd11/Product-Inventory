﻿using System;

namespace App.Shared.Models.Stores.DTO
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