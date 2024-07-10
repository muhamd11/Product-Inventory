using App.Shared.Models.AdditionsModules.LogActionsModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Users
{
    public class User
    {
        public User()
        {
            userLogActions = new HashSet<LogAction>();
        }

        public int userId { get; set; }
        public UserContanctInfo userContanctInfo { get; set; }
        public string userName { get; set; }
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public ICollection<LogAction> userLogActions { get; set; }
    }

    [Owned]
    public class UserContanctInfo
    {
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userCountryCodeName { get; set; }
        public string userCountryCode { get; set; }
        public string userDailCode { get; set; }
        public string userPhoneNumber { get; set; }
        public string userEmail { get; set; }
        public DateOnly userBirthDate { get; set; }
        public DateTime userCreationDate { get; private set; } = DateTime.Now;
        public bool userIsActive { get; set; }
    }
}