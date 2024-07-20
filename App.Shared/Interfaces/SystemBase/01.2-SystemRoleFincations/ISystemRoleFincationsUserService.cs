using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Interfaces.General.Scrutor;
using System.Collections.Generic;

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