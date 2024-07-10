namespace App.Shared.Models.Users
{
    public class UserAddOrUpdateDTO
    {
        public int userId { get; set; }
        public UserContanctInfo userContanctInfo { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}