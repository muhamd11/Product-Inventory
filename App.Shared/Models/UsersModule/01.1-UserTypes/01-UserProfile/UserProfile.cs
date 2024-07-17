﻿using App.Shared.Consts.SystemBase;
using App.Shared.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    [Table($"{nameof(UserProfile)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class UserProfile
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userProfileId { get; set; }

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
        //relations
        [JsonIgnore, ForeignKey(nameof(User))]
        public int userId { get; set; }
    }
}