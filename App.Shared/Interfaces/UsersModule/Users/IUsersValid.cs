using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IUserValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidUserId(int userId);
    }
}