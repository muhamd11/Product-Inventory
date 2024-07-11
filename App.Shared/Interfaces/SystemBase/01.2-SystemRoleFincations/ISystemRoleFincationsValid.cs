using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.DTO;

namespace Api.Controllers.SystemBase.LogActions.Interfaces
{
    public interface ISystemRoleFincationsValid : ITransientService
    {
        public BaseValid ValidGetDetails(int systemRoleId);

        public BaseValid ValidUpdatePrivlage(SystemRoleFincationDto inputModel);
    }
}