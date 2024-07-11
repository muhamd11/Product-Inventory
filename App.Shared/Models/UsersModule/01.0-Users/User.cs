using App.Shared.Models.Buyers;
using App.Shared.Models.Roles;
using App.Shared.Models.SystemBase.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.Users
{
    public class User : BaseEntity
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }
        [ForeignKey(nameof(roleData))]
        public int? roleId { get; set; }
        public Role? roleData { get; set; }
        public Buyer userBuyerData { get; set; }
    }
}