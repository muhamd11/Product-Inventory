using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Interfaces.General.Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.SystemBase._01._2_SystemRoleFincations
{
    public interface ISystemRoleFincationsUserService : ISingletonService
    {
        List<SystemRoleFincation> GetSystemRoleFincations();
    }
    
    public interface ISystemRoleFincationsMangerService : ISystemRoleFincationsUserService
    {
        
    }
    public interface ISystemRoleFincationsClientService : ISystemRoleFincationsUserService
    {
        
    }
}
