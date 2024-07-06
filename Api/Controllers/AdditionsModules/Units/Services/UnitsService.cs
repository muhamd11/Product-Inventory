using Api.Controllers.AdditionsModules.Units.Interfaces;
using App.Shared;
using App.Shared.Models.AdditionsModules.UnitModule;
using App.Shared.Models.AdditionsModules.UnitModule.DTO;
using App.Shared.Models.AdditionsModules.UnitModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Units.Services
{
    internal class UnitsService : IUnitServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UnitsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<UnitInfo>> GetAllAsync(UnitSearchDto inputModel)
        {
            var select = UnitsAdaptor.SelectExpressionUnitInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Units.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Unit, bool>>> GenrateCriteria(UnitSearchDto inputModel)
        {
            List<Expression<Func<Unit, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.unitName.Contains(inputModel.textSearch)
                || x.unitDescription.Contains(inputModel.textSearch)
                || x.unitSympol.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.unitId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<UnitInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = UnitsAdaptor.SelectExpressionUnitDetails();

            Expression<Func<Unit, bool>> criteria = (x) => x.unitId == inputModel.elemetId;

            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(criteria, select);

            return unitInfo;
        }

        public async Task<BaseActionDone<UnitInfo>> AddOrUpdate(UnitAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var unit = _mapper.Map<Unit>(inputModel);
            if (isUpdate)
                _unitOfWork.Units.Update(unit);
            else
                await _unitOfWork.Units.AddAsync(unit);

            var isDone = await _unitOfWork.CommitAsync();

            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == unit.unitId, UnitsAdaptor.SelectExpressionUnitDetails());

            return BaseActionDone<UnitInfo>.GenrateBaseActionDone(isDone, unitInfo);
        }

        public async Task<BaseActionDone<UnitInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var unit = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == inputModel.elemetId);

            _unitOfWork.Units.Delete(unit);

            var isDone = await _unitOfWork.CommitAsync();

            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == unit.unitId, UnitsAdaptor.SelectExpressionUnitInfo());

            return BaseActionDone<UnitInfo>.GenrateBaseActionDone(isDone, unitInfo);
        }

        #endregion Methods
    }
}