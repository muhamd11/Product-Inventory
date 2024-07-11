using App.Shared.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Stores;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFincations.Services
{
    public class SystemRoleFincationsClient : ISystemRoleFincationsClientService
    {
        private readonly ISystemRoleFincationsBaseService _systemRoleFincationsBaseService;

        public SystemRoleFincationsClient(ISystemRoleFincationsBaseService systemRoleFincationsBaseService)
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

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleColors()
        {
            List<SystemRoleFincation> systemRoleFincations = [_systemRoleFincationsBaseService.GetFuncationView(nameof(Color))];
            return systemRoleFincations;
        }

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleUnits()
        {
            List<SystemRoleFincation> systemRoleFincations = [_systemRoleFincationsBaseService.GetFuncationView(nameof(Unit))];
            return systemRoleFincations;
        }

        #endregion AdditionsModules

        #region PlacesModules

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleBranches()
        {
            List<SystemRoleFincation> systemRoleFincations = [_systemRoleFincationsBaseService.GetFuncationView(nameof(Branch))];
            return systemRoleFincations;
        }

        private IEnumerable<SystemRoleFincation> GetPrivlageModuleStores()
        {
            List<SystemRoleFincation> systemRoleFincations = [_systemRoleFincationsBaseService.GetFuncationView(nameof(Store))];
            return systemRoleFincations;
        }

        #endregion PlacesModules
    }
}