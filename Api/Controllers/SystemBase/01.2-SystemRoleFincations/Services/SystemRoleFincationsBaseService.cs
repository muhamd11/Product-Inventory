using App.Shared.Consts.SystemBase;
using App.Shared.Interfaces.SystemBase._01._2_SystemRoleFincations;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFincations
{
    public class SystemRoleFincationsBaseService : ISystemRoleFincationsBaseService
    {
        public List<SystemRoleFincation> GetFuncationBasic(string moduleId)
        {
            List<SystemRoleFincation> systemRoleFincations =
            [
                GetFuncationView(moduleId),
                GetFuncationAdd(moduleId),
                GetFuncationUpdate(moduleId),
                GetFuncationDelete(moduleId),
                GetFuncationFinaleDelete(moduleId),
            ];

            return systemRoleFincations;
        }

        //Base Funcations
        public SystemRoleFincation GetFuncationView(string moduleId) => GetFuncation(moduleId, EnumFuncationsType.view);

        public SystemRoleFincation GetFuncationAdd(string moduleId) => GetFuncation(moduleId, EnumFuncationsType.add);

        public SystemRoleFincation GetFuncationUpdate(string moduleId) => GetFuncation(moduleId, EnumFuncationsType.update);

        public SystemRoleFincation GetFuncationDelete(string moduleId) => GetFuncation(moduleId, EnumFuncationsType.delete);

        public SystemRoleFincation GetFuncationFinaleDelete(string moduleId) => GetFuncation(moduleId, EnumFuncationsType.finaleDelete);

        public SystemRoleFincation GetFuncationCustomize(string moduleId, EnumFuncationsType customize) => GetFuncation(moduleId, customize);

        private SystemRoleFincation GetFuncation(string moduleId, EnumFuncationsType enumFuncationsType)
        {
            return new SystemRoleFincation()
            {
                funcationsType = enumFuncationsType,
                moduleId = moduleId,
                funcationId = $"{moduleId}_{enumFuncationsType}",
                isHavePrivlage = false
            };
        }

    }
}