using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IBaseUserValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(BaseUserAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid IsValidUser(BaseUserAddOrUpdateDTO inputModel);

        public BaseValid IsValidUserId(int userId);

        public BaseValid IsValidUserInfo(BaseUserAddOrUpdateDTO inputModel);

        public BaseValid IsUserInfoAddedBefore(BaseUserAddOrUpdateDTO inputModel);
    }
}