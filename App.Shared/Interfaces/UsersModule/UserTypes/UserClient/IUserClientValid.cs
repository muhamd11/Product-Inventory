using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.UsersModule._01._1_UserTypes._01._2_UserClientData.DTO;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IUserClientValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(UserClientAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid ValidDelete(BaseDeleteDto inputModel);
    }
}