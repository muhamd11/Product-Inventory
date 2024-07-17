using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Models.SystemBase._01._2_SystemRoleFincations.ViewModel
{
    public class SystemRoleFunctionInfo
    {
        public string systemRoleFunctionModule { get; set; }
        public List<SystemRoleFincation> systemRoleFunctions { get; set; } = new List<SystemRoleFincation>();
    }
}
