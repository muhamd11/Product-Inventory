using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.Buyers;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IUserClientsValid : ITransientService
    {
        BaseValid IsValidUserClient(UserClient inputModel);
    }
}