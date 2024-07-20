using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using System.Collections.Generic;

namespace App.Shared.Models.SystemBase._01._2_SystemRoleFincations.ViewModel
{
    public class SystemRoleFunctionInfo
    {
        public string systemRoleFunctionModule { get; set; }
        public List<SystemRoleFincation> systemRoleFunctions { get; set; } = new List<SystemRoleFincation>();
    }
}