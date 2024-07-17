using App.Shared.Consts.Users;
using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.Users;
using System.Collections.Generic;

namespace App.Shared.Models.SystemBase.Roles
{
    public class SystemRole : BaseEntity
    {
        public SystemRole()
        {
            usersData = new HashSet<User>();
        }

        public int systemRoleId { get; set; }
        public string systemRoleName { get; set; }
        public string systemRoleDescription { get; set; }
        public EnumUserType systemRoleUserType { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
        public ICollection<User> usersData { get; set; }
    }
}