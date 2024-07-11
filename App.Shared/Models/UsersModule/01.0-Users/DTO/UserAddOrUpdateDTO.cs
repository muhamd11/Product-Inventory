using App.Shared.Models.Buyers;

namespace App.Shared.Models.Users
{
    public class UserAddOrUpdateDTO
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public int roleId { get; set; }
        public BuyerAddOrUpdateDTO userBuyerData { get; set; }
    }
}