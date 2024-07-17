using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.UsersModule.Users
{
    public interface IUsersServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UserInfo>> GetAllAsync(UserSearchDto inputModel);

        Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}