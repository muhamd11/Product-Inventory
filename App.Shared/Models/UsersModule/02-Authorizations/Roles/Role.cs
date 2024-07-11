using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.Users;
using System.Collections.Generic;

namespace App.Shared.Models.Roles
{
    public class Role : BaseEntity
    {
        public Role()
        {
            usersData = new HashSet<User>();
        }

        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public ICollection<User>? usersData { get; set; }
    }
}