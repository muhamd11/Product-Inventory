using System.Text.Json.Serialization;

namespace App.Shared.Models.Users
{
    public class UserInfoDetails : UserInfo
    {
        [JsonPropertyOrder(3)]
        public string userName { get; set; }
    }
}