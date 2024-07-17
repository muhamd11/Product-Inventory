using App.Shared;
using App.Shared.Consts.Users;
using App.Shared.Interfaces.UsersModule.UserTypes.UserClient;
using App.Shared.Models.Buyers;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule._01._1_UserTypes._01._2_UserClientData.DTO;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.DTO;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserService : IUserClientServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<UserClientInfo>> GetAllAsync(UserClientSearchDTO inputModel)
        {
            var select = UserClientsAdaptor.SelectExpressionUserClientInfo();

            var criteria = GenrateCriteria(inputModel);

            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);
            includes.Add(x => x.userClientData.userProductWishList);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Users.GetAllAsync(select, criteria, paginationRequest, includes);
        }

        private List<Expression<Func<User, bool>>> GenrateCriteria(UserClientSearchDTO inputModel)
        {
            List<Expression<Func<User, bool>>> criteria = [];
            // TODO: Complete Search Function For User
            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.userName.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.userId == inputModel.elemetId.Value);

            criteria.Add(x => x.userType == EnumUserType.Client);

            return criteria;
        }

        public async Task<UserClientInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = UserClientsAdaptor.SelectExpressionUserClientDetails();

            Expression<Func<User, bool>> criteria = (x) => x.userId == inputModel.elementId && x.userType == EnumUserType.Client;

            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);
            includes.Add(x => x.userClientData.userProductWishList);

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select, includes);

            return userInfo;
        }

        public async Task<BaseActionDone<UserClientInfo>> AddOrUpdate(UserClientAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var user = _mapper.Map<User>(inputModel);
            var userClientData = _mapper.Map<UserClient>(inputModel.userClientData);
            if (isUpdate)
                _unitOfWork.Users.Update(user);
            else
            {
                user.userClientData = userClientData;
                await _unitOfWork.Users.AddAsync(user);
            }

            var isDone = await _unitOfWork.CommitAsync();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == user.userId, UserClientsAdaptor.SelectExpressionUserClientInfo());

            return BaseActionDone<UserClientInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        public async Task<BaseActionDone<UserClientInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == inputModel.elementId);

            _unitOfWork.Users.Delete(user);

            var isDone = await _unitOfWork.CommitAsync();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == user.userId, UserClientsAdaptor.SelectExpressionUserClientInfo());

            return BaseActionDone<UserClientInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        #endregion Methods
    }
}