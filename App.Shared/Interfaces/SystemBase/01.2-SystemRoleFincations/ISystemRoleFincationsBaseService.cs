using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Consts.SystemBase;
using App.Shared.Interfaces.General.Scrutor;
using System.Collections.Generic;

namespace App.Shared.Interfaces.SystemBase._01._2_SystemRoleFincations
{
    public interface ISystemRoleFincationsBaseService : ISingletonService
    {
        public List<SystemRoleFincation> GetFuncationBasic(string moduleId);

        //Base Funcations
        public SystemRoleFincation GetFuncationView(string moduleId);

        public SystemRoleFincation GetFuncationAdd(string moduleId);

        public SystemRoleFincation GetFuncationUpdate(string moduleId);

        public SystemRoleFincation GetFuncationDelete(string moduleId);

        public SystemRoleFincation GetFuncationFinaleDelete(string moduleId);

        public SystemRoleFincation GetFuncationCustomize(string moduleId, EnumFuncationsType customize);
    }
}