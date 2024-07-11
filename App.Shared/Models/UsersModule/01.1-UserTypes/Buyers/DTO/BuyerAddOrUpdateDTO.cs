using System;

namespace App.Shared.Models.Buyers
{
    public class BuyerAddOrUpdateDTO
    {
        public string buyerFirstName { get; set; }
        public string buyerLastName { get; set; }
        public string buyerCountryCodeName { get; set; }
        public string buyerCountryCode { get; set; }
        public string buyerDailCode { get; set; }
        public string buyerPhoneNumber { get; set; }
        public string buyerEmail { get; set; }
        public DateOnly buyerBirthDate { get; set; }
        public bool buyerIsActive { get; set; }
    }
}