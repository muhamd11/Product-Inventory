using Api.Controllers.AdditionsModules.Categories.Interfaces;
using App.Shared;
using App.Shared.Models.AdditionsModules.CategoryModule;
using App.Shared.Models.AdditionsModules.CategoryModule.DTO;
using App.Shared.Models.AdditionsModules.CategoryModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Categories.Services
{
    internal class CategoriesService : ICategoryServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public CategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<CategoryInfo>> GetAllAsync(CategorySearchDto inputModel)
        {
            var select = CategoriesAdaptor.SelectExpressionCategoryInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Categories.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Category, bool>>> GenrateCriteria(CategorySearchDto inputModel)
        {
            List<Expression<Func<Category, bool>>> criteria = null;

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.categoryName.Contains(inputModel.textSearch)
                || x.categoryDescription.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.categoryId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<CategoryInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = CategoriesAdaptor.SelectExpressionCategoryDetails();

            Expression<Func<Category, bool>> criteria = (x) => x.categoryId == inputModel.elementId;

            var categoryInfo = await _unitOfWork.Categories.FirstOrDefaultAsync(criteria, select);

            return categoryInfo;
        }

        public async Task<BaseActionDone<CategoryInfo>> AddOrUpdate(CategoryAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var category = _mapper.Map<Category>(inputModel);
            if (isUpdate)
                _unitOfWork.Categories.Update(category);
            else
                await _unitOfWork.Categories.AddAsync(category);

            var isDone = await _unitOfWork.CommitAsync();

            var categoryInfo = await _unitOfWork.Categories.FirstOrDefaultAsync(x => x.categoryId == category.categoryId, CategoriesAdaptor.SelectExpressionCategoryDetails());

            return BaseActionDone<CategoryInfo>.GenrateBaseActionDone(isDone, categoryInfo);
        }

        public async Task<BaseActionDone<CategoryInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var category = await _unitOfWork.Categories.FirstOrDefaultAsync(x => x.categoryId == inputModel.elementId);

            _unitOfWork.Categories.Delete(category);

            var isDone = await _unitOfWork.CommitAsync();

            var categoryInfo = await _unitOfWork.Categories.FirstOrDefaultAsync(x => x.categoryId == category.categoryId, CategoriesAdaptor.SelectExpressionCategoryInfo());

            return BaseActionDone<CategoryInfo>.GenrateBaseActionDone(isDone, categoryInfo);
        }

        #endregion Methods
    }
}