using App.Shared.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    public class UserProfile
    {
        [Key, JsonIgnore]
        public int userId { get; set; }
        //phone-4
        public string userPhone_2 { get; set; }

        public string userPhoneDialCode_2 { get; set; }
        public string userPhoneCC_2 { get; set; }
        public string userPhoneCCName_2 { get; set; }

        //phone-4
        public string userPhone_3 { get; set; }

        public string userPhoneDialCode_3 { get; set; }
        public string userPhoneCC_3 { get; set; }
        public string userPhoneCCName_3 { get; set; }

        //phone-4
        public string userPhone_4 { get; set; }

        public string userPhoneDialCode_4 { get; set; }
        public string userPhoneCC_4 { get; set; }
        public string userPhoneCCName_4 { get; set; }

        public string userContactEmail { get; set; }
        public DateOnly userBirthDate { get; set; }
    }
}