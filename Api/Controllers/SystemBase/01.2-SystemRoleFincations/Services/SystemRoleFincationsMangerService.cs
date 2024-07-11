using App.Shared.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Stores;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFincations.Services
{
    public class SystemRoleFincationsMangerService : ISystemRoleFincationsMangerService
    {
        private readonly ISystemRoleFincationsBaseService _systemRoleFincationsBaseService;

        public SystemRoleFincationsMangerService(ISystemRoleFincationsBaseService systemRoleFincationsBaseService)
        {
            _systemRoleFincationsBaseService = systemRoleFincationsBaseService;
        }

        public List<SystemRoleFincation> GetSystemRoleFincations()
        {
            List<SystemRoleFincation> systemRoleFincations = new List<SystemRoleFincation>();
            //AdditionsModules
            systemRoleFincations.AddRange(GetPrivlageModuleColors());
            systemRoleFincations.AddRange(GetPrivlageModuleUnits());
            //PlacesModules
            systemRoleFincations.AddRange(GetPrivlageModuleBranches());
            systemRoleFincations.AddRange(GetPrivlageModuleStores());

            return systemRoleFincations;
        }

        #region AdditionsModules

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleColors() =>
            _systemRoleFincationsBaseService.GetFuncationBasic(nameof(Color));

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleUnits() =>
            _systemRoleFincationsBaseService.GetFuncationBasic(nameof(Unit));

        #endregion AdditionsModules

        #region PlacesModules

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleBranches() =>
            _systemRoleFincationsBaseService.GetFuncationBasic(nameof(Branch));

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleStores() =>
            _systemRoleFincationsBaseService.GetFuncationBasic(nameof(Store));

        #endregion PlacesModules
    }
}