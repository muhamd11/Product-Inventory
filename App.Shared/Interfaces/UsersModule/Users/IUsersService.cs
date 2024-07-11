using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;
using System.Threading.Tasks;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IUserServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UserInfo>> GetAllAsync(UserSearchDto inputModel);

        Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}