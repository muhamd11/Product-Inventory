using App.Shared.Models.Roles;
using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    public class Buyer : BaseEntity
    {
        [JsonIgnore, Key,ForeignKey(nameof(User))]
        public int userId { get; set; }
        [JsonIgnore]
        public User user { get; set; }
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