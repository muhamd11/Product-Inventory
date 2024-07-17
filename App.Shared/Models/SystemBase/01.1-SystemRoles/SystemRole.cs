using App.Shared.Consts.SystemBase;
using App.Shared.Consts.Users;
using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule.LogActionsModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.SystemBase.Roles
{
    [Table($"{nameof(SystemRole)}s", Schema = nameof(EnumDatabaseSchema.SystemBase))]

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