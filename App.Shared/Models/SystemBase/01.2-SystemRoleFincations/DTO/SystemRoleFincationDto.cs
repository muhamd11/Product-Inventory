using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Models.SystemBase._01._2_SystemRoleFincations.DTO
{
    public class SystemRoleFincationDto
    {
        public SystemRoleFincationDto()
        {
            systemRoleFincations= new HashSet<SystemRoleFincation>();
        }
        public int systemRoleId { get; set; }
        public ICollection<SystemRoleFincation> systemRoleFincations { get; set; }
    }
}
