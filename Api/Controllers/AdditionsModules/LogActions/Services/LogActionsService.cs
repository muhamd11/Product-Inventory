using Api.Controllers.AdditionsModules.LogActions.Interfaces;
using App.Shared;
using App.Shared.Models.AdditionsModules.LogActionsModel;
using App.Shared.Models.AdditionsModules.LogActionsModel.DTO;
using App.Shared.Models.AdditionsModules.LogActionsModel.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.Products;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.LogActions.Services
{
    internal class LogActionsService : ILogActionServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public LogActionsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<LogActionInfo>> GetAllAsync(LogActionSearchDto inputModel)
        {
            var select = LogActionsAdaptor.SelectExpressionLogActionInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.LogActions.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<LogAction, bool>>> GenrateCriteria(LogActionSearchDto inputModel)
        {
            List<Expression<Func<LogAction, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x => x.oldData.Contains(inputModel.textSearch)
                || x.newData.Contains(inputModel.textSearch));
            }

            if (!inputModel.modelName.IsNullOrEmpty())
                criteria.Add(x => x.modelName == inputModel.modelName);
            
            if (inputModel.userId.HasValue)
                criteria.Add(x => x.userId == inputModel.userId);

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.logActionId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<LogActionInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = LogActionsAdaptor.SelectExpressionLogActionDetails();

            Expression<Func<LogAction, bool>> criteria = (x) => x.logActionId == inputModel.elementId;

            var logActionInfo = await _unitOfWork.LogActions.FirstOrDefaultAsync(criteria, select);
            return logActionInfo;
        }

        public async Task<BaseActionDone<LogActionInfo>> AddOrUpdate(LogActionAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var logAction = _mapper.Map<LogAction>(inputModel);

            if (isUpdate)
                _unitOfWork.LogActions.Update(logAction);
            else
                await _unitOfWork.LogActions.AddAsync(logAction);

            var isDone = await _unitOfWork.CommitAsync();

            var logActionInfo = await _unitOfWork.LogActions.FirstOrDefaultAsync(x => x.logActionId == logAction.logActionId, LogActionsAdaptor.SelectExpressionLogActionDetails());

            return BaseActionDone<LogActionInfo>.GenrateBaseActionDone(isDone, logActionInfo);
        }

        public async Task<BaseActionDone<LogActionInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            LogAction logAction = await _unitOfWork.LogActions.FirstOrDefaultAsync(x => x.logActionId == inputModel.elementId);

            _unitOfWork.LogActions.Delete(logAction);

            var isDone = await _unitOfWork.CommitAsync();

            var loActionInfo = await _unitOfWork.LogActions.FirstOrDefaultAsync(x => x.logActionId == logAction.logActionId, LogActionsAdaptor.SelectExpressionLogActionInfo());

            return BaseActionDone<LogActionInfo>.GenrateBaseActionDone(isDone, loActionInfo);
        }

        #endregion Methods
    }
}