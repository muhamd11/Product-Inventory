using App.Shared;
using App.Shared.Interfaces.AdditionsModules.Colors;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Colors.DTO;
using App.Shared.Models.AdditionsModules.Shared.Colors.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Shared.Colors
{
    internal class ColorService : IColorServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<ColorInfo>> GetAllAsync(ColorSearchDto inputModel)
        {
            var select = ColorsAdaptor.SelectExpressionColorInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Colors.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Color, bool>>> GenrateCriteria(ColorSearchDto inputModel)
        {
            List<Expression<Func<Color, bool>>> criteria = null;

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.colorName.Contains(inputModel.textSearch)
                || x.colorDescription.Contains(inputModel.textSearch)
                || x.colorHexCode.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.colorId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<ColorInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = ColorsAdaptor.SelectExpressionColorDetails();

            Expression<Func<Color, bool>> criteria = (x) => x.colorId == inputModel.elementId;

            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(criteria, select);

            return colorInfo;
        }

        public async Task<BaseActionDone<ColorInfo>> AddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var color = _mapper.Map<Color>(inputModel);
            if (isUpdate)
                _unitOfWork.Colors.Update(color);
            else
                await _unitOfWork.Colors.AddAsync(color);

            var isDone = await _unitOfWork.CommitAsync();

            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.colorId == color.colorId, ColorsAdaptor.SelectExpressionColorDetails());

            return BaseActionDone<ColorInfo>.GenrateBaseActionDone(isDone, colorInfo);
        }

        public async Task<BaseActionDone<ColorInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var color = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.colorId == inputModel.elementId);

            _unitOfWork.Colors.Delete(color);

            var isDone = await _unitOfWork.CommitAsync();

            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.colorId == color.colorId, ColorsAdaptor.SelectExpressionColorInfo());

            return BaseActionDone<ColorInfo>.GenrateBaseActionDone(isDone, colorInfo);
        }

        #endregion Methods
    }
}