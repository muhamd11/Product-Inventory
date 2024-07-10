using Microsoft.EntityFrameworkCore;
using System;

namespace App.Shared.Models.Users
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }
        public UserContanctInfo userContanctInfo { get; set; }
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