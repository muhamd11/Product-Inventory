using App.Shared;
using App.Shared.Interfaces.SystemBase.SystemRoles;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.SystemRoles
{
    internal class SystemRoleService : ISystemRolesServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public SystemRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<SystemRoleInfo>> GetAllAsync(SystemRoleSearchDto inputModel)
        {
            var select = SystemRolesAdaptor.SelectExpressionSystemRoleInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.SystemRoles.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<SystemRole, bool>>> GenrateCriteria(SystemRoleSearchDto inputModel)
        {
            List<Expression<Func<SystemRole, bool>>> criteria = [];
            // TODO: Complete Search Function For SystemRole
            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.systemRoleName.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.systemRoleId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<SystemRoleInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = SystemRolesAdaptor.SelectExpressionSystemRoleDetails();

            Expression<Func<SystemRole, bool>> criteria = (x) => x.systemRoleId == inputModel.elementId;

            List<Expression<Func<SystemRole, object>>> includes = [];

            includes.Add(x => x.usersData);

            var systemRoleInfo = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(criteria, select, includes);

            return systemRoleInfo;
        }

        public async Task<BaseActionDone<SystemRoleInfo>> AddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var systemRole = _mapper.Map<SystemRole>(inputModel);
            if (isUpdate)
                _unitOfWork.SystemRoles.Update(systemRole);
            else
                await _unitOfWork.SystemRoles.AddAsync(systemRole);

            var isDone = await _unitOfWork.CommitAsync();

            var systemRoleInfo = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleId == systemRole.systemRoleId, SystemRolesAdaptor.SelectExpressionSystemRoleDetails());

            return BaseActionDone<SystemRoleInfo>.GenrateBaseActionDone(isDone, systemRoleInfo);
        }

        public async Task<BaseActionDone<SystemRoleInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var systemRole = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleId == inputModel.elementId);

            _unitOfWork.SystemRoles.Delete(systemRole);

            var isDone = await _unitOfWork.CommitAsync();

            var systemRoleInfo = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleId == systemRole.systemRoleId, SystemRolesAdaptor.SelectExpressionSystemRoleInfo());

            return BaseActionDone<SystemRoleInfo>.GenrateBaseActionDone(isDone, systemRoleInfo);
        }

        #endregion Methods
    }
}