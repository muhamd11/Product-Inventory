using Api.Controllers.Authorizations.Roles.Interfaces;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.Authorizations.Roles.Services
{
    internal class RoleService : IRoleServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<RoleInfo>> GetAllAsync(RoleSearchDto inputModel)
        {
            var select = RoleAdaptor.SelectExpressionRoleInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Roles.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<SystemRole, bool>>> GenrateCriteria(RoleSearchDto inputModel)
        {
            List<Expression<Func<SystemRole, bool>>> criteria = [];
            // TODO: Complete Search Function For Role
            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.systemRoleName.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.systemRoleId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<RoleInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = RoleAdaptor.SelectExpressionRoleDetails();

            Expression<Func<SystemRole, bool>> criteria = (x) => x.systemRoleId == inputModel.elementId;

            List<Expression<Func<SystemRole, object>>> includes = [];

            includes.Add(x => x.usersData);

            var roleInfo = await _unitOfWork.Roles.FirstOrDefaultAsync(criteria, select, includes);

            return roleInfo;
        }

        public async Task<BaseActionDone<RoleInfo>> AddOrUpdate(RoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var role = _mapper.Map<SystemRole>(inputModel);
            if (isUpdate)
                _unitOfWork.Roles.Update(role);
            else
                await _unitOfWork.Roles.AddAsync(role);

            var isDone = await _unitOfWork.CommitAsync();

            var roleInfo = await _unitOfWork.Roles.FirstOrDefaultAsync(x => x.systemRoleId == role.systemRoleId, RoleAdaptor.SelectExpressionRoleDetails());

            return BaseActionDone<RoleInfo>.GenrateBaseActionDone(isDone, roleInfo);
        }

        public async Task<BaseActionDone<RoleInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var role = await _unitOfWork.Roles.FirstOrDefaultAsync(x => x.systemRoleId == inputModel.elementId);

            _unitOfWork.Roles.Delete(role);

            var isDone = await _unitOfWork.CommitAsync();

            var roleInfo = await _unitOfWork.Roles.FirstOrDefaultAsync(x => x.systemRoleId == role.systemRoleId, RoleAdaptor.SelectExpressionRoleInfo());

            return BaseActionDone<RoleInfo>.GenrateBaseActionDone(isDone, roleInfo);
        }

        #endregion Methods
    }
}