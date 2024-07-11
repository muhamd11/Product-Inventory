using Api.Controllers.PlacesModules.Branches.Interfaces;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Branches.DTO;
using App.Shared.Models.PlacesModules.Branches.ViewModel;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.PlacesModules.Branches
{
    internal class BranchesService : IBranchesService
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public BranchesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<BranchInfo>> GetAllAsync(BranchSearchDto inputModel)
        {
            var select = BranchesAdaptor.SelectExpressionBranchInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Branches.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Branch, bool>>> GenrateCriteria(BranchSearchDto inputModel)
        {
            List<Expression<Func<Branch, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.branchContactInfo.branchName.Contains(inputModel.textSearch)
                || x.branchContactInfo.branchAddress.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.branchId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<BranchInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = BranchesAdaptor.SelectExpressionBranchDetails();

            Expression<Func<Branch, bool>> criteria = (x) => x.branchId == inputModel.elementId;

            var branchInfo = await _unitOfWork.Branches.FirstOrDefaultAsync(criteria, select);

            return branchInfo;
        }

        public async Task<BaseActionDone<BranchInfo>> AddOrUpdate(BranchAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var branch = _mapper.Map<Branch>(inputModel);
            if (isUpdate)
                _unitOfWork.Branches.Update(branch);
            else
                await _unitOfWork.Branches.AddAsync(branch);

            var isDone = await _unitOfWork.CommitAsync();

            var branchInfo = await _unitOfWork.Branches.FirstOrDefaultAsync(x => x.branchId == branch.branchId, BranchesAdaptor.SelectExpressionBranchDetails());

            return BaseActionDone<BranchInfo>.GenrateBaseActionDone(isDone, branchInfo);
        }

        public async Task<BaseActionDone<BranchInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var branch = await _unitOfWork.Branches.FirstOrDefaultAsync(x => x.branchId == inputModel.elementId);

            _unitOfWork.Branches.Delete(branch);

            var isDone = await _unitOfWork.CommitAsync();

            var branchInfo = await _unitOfWork.Branches.FirstOrDefaultAsync(x => x.branchId == branch.branchId, BranchesAdaptor.SelectExpressionBranchInfo());

            return BaseActionDone<BranchInfo>.GenrateBaseActionDone(isDone, branchInfo);
        }

        #endregion Methods
    }
}