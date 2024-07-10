using Api.Controllers.UsersModules.Users.Interfaces;
using Api.Controllers.UsersModules.Users.Users.Services;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.Users;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules.Users.Services
{
    internal class UserService : IUserServices
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

        public async Task<BaseGetDataWithPagnation<UserInfo>> GetAllAsync(UserSearchDto inputModel)
        {
            var select = UserAdaptor.SelectExpressionUserInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Users.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<User, bool>>> GenrateCriteria(UserSearchDto inputModel)
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

            return criteria;
        }

        public async Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = UserAdaptor.SelectExpressionUserDetails();

            Expression<Func<User, bool>> criteria = (x) => x.userId == inputModel.elementId;

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select);

            return userInfo;
        }

        public async Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var user = _mapper.Map<User>(inputModel);
            if (isUpdate)
                _unitOfWork.Users.Update(user);
            else
                await _unitOfWork.Users.AddAsync(user);

            var isDone = await _unitOfWork.CommitAsync();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == user.userId, UserAdaptor.SelectExpressionUserDetails());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        public async Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == inputModel.elementId);

            _unitOfWork.Users.Delete(user);

            var isDone = await _unitOfWork.CommitAsync();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == user.userId, UserAdaptor.SelectExpressionUserInfo());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        #endregion Methods
    }
}