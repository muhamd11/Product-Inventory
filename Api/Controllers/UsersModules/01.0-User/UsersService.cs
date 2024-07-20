﻿using App.Shared;
using App.Shared.Consts.Users;
using App.Shared.Interfaces.UsersModule.Users;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using App.Shared.Models.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserService : IUsersServices
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
            var select = UsersAdaptor.SelectExpressionUserClientInfo();

            var criteria = GenrateCriteria(inputModel);

            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Users.GetAllAsync(select, criteria, paginationRequest, includes);
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
            var select = UsersAdaptor.SelectExpressionUserClientDetails();

            Expression<Func<User, bool>> criteria = (x) => x.userId == inputModel.elementId && x.userType == EnumUserType.Client;

            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);
            includes.Add(x => x.userProfile);

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select, includes);

            return userInfo;
        }

        public async Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var user = _mapper.Map<User>(inputModel);

            if (isUpdate)
                _unitOfWork.Users.Update(user);
            else
                user = await _unitOfWork.Users.AddAsync(user);

            var isDone = await _unitOfWork.CommitAsync();

            if (isDone > 0)
                SyncProfiles(user.userId, inputModel);

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == user.userId, UsersAdaptor.SelectExpressionUserClientInfo());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        private async void SyncProfiles(int userId, UserAddOrUpdateDTO inputModel)
        {
            //delete
            _unitOfWork.UserProfiles.AsQueryable().Where(x => x.userId == userId).ExecuteDelete();
            _unitOfWork.UserClients.AsQueryable().Where(x => x.userId == userId).ExecuteDelete();
            _unitOfWork.UserEmployees.AsQueryable().Where(x => x.userId == userId).ExecuteDelete();
            await _unitOfWork.CommitAsync();
            //add

            //userProfile scope
            {
                //null save
                inputModel.userProfileData = inputModel.userProfileData ?? new();
                inputModel.userProfileData.userId = userId;
                await _unitOfWork.UserProfiles.AddAsync(inputModel.userProfileData);
                await _unitOfWork.CommitAsync();
            }

            if (inputModel.userType == EnumUserType.Client)
            {
                //null save
                inputModel.userClientData = inputModel.userClientData ?? new();
                inputModel.userClientData.userId = userId;
                await _unitOfWork.UserClients.AddAsync(inputModel.userClientData);
                await _unitOfWork.CommitAsync();
            }
            else if (inputModel.userType == EnumUserType.Employe)
            {
                //null save
                inputModel.userEmployeeData = inputModel.userEmployeeData ?? new();
                inputModel.userEmployeeData.userId = userId;
                await _unitOfWork.UserEmployees.AddAsync(inputModel.userEmployeeData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == inputModel.elementId);

            _unitOfWork.Users.Delete(user);

            var isDone = await _unitOfWork.CommitAsync();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userId == user.userId, UsersAdaptor.SelectExpressionUserClientInfo());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        #endregion Methods
    }
}