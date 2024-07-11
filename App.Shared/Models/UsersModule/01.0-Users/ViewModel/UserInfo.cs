﻿using App.Shared.Consts.Users;

namespace App.Shared.Models.Users
{
    public class UserInfo
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPhone { get; set; }
        public EnumUserType userType { get; set; }
    }
}