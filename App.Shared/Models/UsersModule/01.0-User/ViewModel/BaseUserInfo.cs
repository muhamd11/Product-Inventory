using App.Shared.Consts.Users;
using App.Shared.Models.SystemBase.BaseClass;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Users
{
    public class BaseUserInfo : BaseEntityInfo
    {
        [JsonPropertyOrder(-5)]
        public int userId { get; set; }
        [JsonPropertyOrder(-4)]
        public string userName { get; set; }
        [JsonPropertyOrder(-3)]
        public string userEmail { get; set; }
        [JsonPropertyOrder(-2)]
        public string userPhone { get; set; }
        [JsonPropertyOrder(-1)]
        public EnumUserType userType { get; set; }
    }
}