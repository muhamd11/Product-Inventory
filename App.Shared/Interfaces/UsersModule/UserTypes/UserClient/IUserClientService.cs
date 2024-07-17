using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule._01._1_UserTypes._01._2_UserClientData.DTO;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.DTO;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.UsersModule.UserTypes.UserClient
{
    public interface IUserClientServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UserClientInfo>> GetAllAsync(UserClientSearchDTO inputModel);

        Task<UserClientInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UserClientInfo>> AddOrUpdate(UserClientAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UserClientInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}