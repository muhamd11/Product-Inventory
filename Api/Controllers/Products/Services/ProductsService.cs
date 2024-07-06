using Api.Controllers.AdditionsModules.Products.Interfaces;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.Products;
using App.Shared.Models.Products.DTO;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Products.Services
{
    internal class ProductService : IProductServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<ProductInfo>> GetAllAsync(ProductSearchDto inputModel)
        {
            var select = ProductAdaptor.SelectExpressionProductInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Products.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Product, bool>>> GenrateCriteria(ProductSearchDto inputModel)
        {
            List<Expression<Func<Product, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.productName.Contains(inputModel.textSearch)
                || x.productDescription.Contains(inputModel.textSearch)
                || x.categoryData.Any(c => c.categoryName.Contains(inputModel.textSearch)));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.productId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<ProductInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = ProductAdaptor.SelectExpressionProductDetails();

            Expression<Func<Product, bool>> criteria = (x) => x.productId == inputModel.elemetId;

            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(criteria, select);

            return productInfo;
        }

        public async Task<BaseActionDone<ProductInfo>> AddOrUpdate(ProductAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var product = _mapper.Map<Product>(inputModel);
            if (isUpdate)
                _unitOfWork.Products.Update(product);
            else
                await _unitOfWork.Products.AddAsync(product);

            var isDone = await _unitOfWork.CommitAsync();

            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == product.productId, ProductAdaptor.SelectExpressionProductDetails());

            return BaseActionDone<ProductInfo>.GenrateBaseActionDone(isDone, productInfo);
        }

        public async Task<BaseActionDone<ProductInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var product = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == inputModel.elemetId);

            _unitOfWork.Products.Delete(product);

            var isDone = await _unitOfWork.CommitAsync();

            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == product.productId, ProductAdaptor.SelectExpressionProductInfo());

            return BaseActionDone<ProductInfo>.GenrateBaseActionDone(isDone, productInfo);
        }

        #endregion Methods
    }
}