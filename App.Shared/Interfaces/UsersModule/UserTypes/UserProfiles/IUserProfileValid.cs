using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.Buyers;
using App.Shared.Models.General.LocalModels;

namespace App.Shared.Interfaces.UsersModule.UserTypes.UserProfiles
{
    public interface IUserProfileValid : ITransientService
    {
        BaseValid IsValidUserProfile(UserProfile inputModel);
    }
}