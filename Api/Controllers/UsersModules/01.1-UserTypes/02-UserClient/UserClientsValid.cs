using Api.Controllers.UsersModules.Users.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Models.Buyers;
using App.Shared.Models.General.LocalModels;
using App.Shared.Resources.General;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserClientValid : IUserClientsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserClientValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods


        public BaseValid IsValidUserClient(UserClient inputModel)
        {
            if (inputModel is not null)
            {
                #region ValidateUserClient

                #endregion ValidateUserClient
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }


        #endregion Methods
    }
}