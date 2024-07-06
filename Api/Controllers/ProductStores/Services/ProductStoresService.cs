using Api.Controllers.AdditionsModules.ProductProducts.Interfaces;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.ProductStores;
using App.Shared.Models.ProductStores.DTO;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.ProductProducts.Services
{
    internal class ProductStoresService : IProductStoreServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ProductStoresService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<ProductStoreInfo>> GetAllAsync(ProductStoreSearchDTO inputModel)
        {
            var select = ProductStoresAdaptor.SelectExpressionProductStoreInfo();

            var criteria = GenrateCriteria(inputModel);

            var includes = new List<Expression<Func<ProductStore, object>>>
            {
                x => x.productData,
                x => x.unitData,
                x => x.colorData
            };

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.ProductStores.GetAllAsync(select, criteria, paginationRequest, includes);
        }

        private List<Expression<Func<ProductStore, bool>>> GenrateCriteria(ProductStoreSearchDTO inputModel)
        {
            List<Expression<Func<ProductStore, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x => x.productData.productName.Contains(inputModel.textSearch)
                               || x.colorData.colorName.Contains(inputModel.textSearch)
                               || x.unitData.unitName.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.productStoreId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<ProductStoreInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = ProductStoresAdaptor.SelectExpressionProductStoreDetails();

            Expression<Func<ProductStore, bool>> criteria = (x) => x.productStoreId == inputModel.elemetId;

            var productStoreInfo = await _unitOfWork.ProductStores.FirstOrDefaultAsync(criteria, select);

            return productStoreInfo;
        }

        public async Task<BaseActionDone<ProductStoreInfo>> AddOrUpdate(ProductStoreAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var productStore = _mapper.Map<ProductStore>(inputModel);
            if (isUpdate)
                _unitOfWork.ProductStores.Update(productStore);
            else
                await _unitOfWork.ProductStores.AddAsync(productStore);

            var isDone = await _unitOfWork.CommitAsync();

            var productStoreInfo = await _unitOfWork.ProductStores.FirstOrDefaultAsync(x => x.productStoreId == productStore.productStoreId, ProductStoresAdaptor.SelectExpressionProductStoreInfo());

            return BaseActionDone<ProductStoreInfo>.GenrateBaseActionDone(isDone, productStoreInfo);
        }

        public async Task<BaseActionDone<ProductStoreInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var productStore = await _unitOfWork.ProductStores.FirstOrDefaultAsync(x => x.productStoreId == inputModel.elemetId);

            _unitOfWork.ProductStores.Delete(productStore);

            var isDone = await _unitOfWork.CommitAsync();

            var productStoreInfo = await _unitOfWork.ProductStores.FirstOrDefaultAsync(x => x.productStoreId == productStore.productStoreId, ProductStoresAdaptor.SelectExpressionProductStoreInfo());

            return BaseActionDone<ProductStoreInfo>.GenrateBaseActionDone(isDone, productStoreInfo);
        }

        #endregion Methods
    }
}