using App.Core;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.ColorModule.ViewModel;
using App.Shared.Models.General;
using App.Shared.Models.ProductModule;
using App.Shared.Models.ProductModule.Contracts.DTO;
using App.Shared.Models.ProductModule.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.ProductModule
{
    public class ProductServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<(IEnumerable<ProductInfo>, Pagination)> GetAllAsync(string? textSearch = null, PaginationRequest? paginationRequest = null)
        {
            Expression<Func<Product, bool>> criteria = null;
            paginationRequest = paginationRequest ?? new PaginationRequest();

            if (!string.IsNullOrEmpty(textSearch))
                criteria = (x) => EF.Functions.Like(x.productName, $"%{textSearch}%");

            var (Colors, pagination) = await _unitOfWork.Products.GetAllAsync(selectionProductInfo(), criteria, paginationRequest);

            return (Colors, pagination);
        }

        public async Task<ProductInfoDetails> GetDetails(int id)
        {
            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == id, selectionProductInfoDetails());
            return productInfo;
        }

        public async Task<ProductInfoDetails> AddAsync(AddProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == product.productId, selectionProductInfoDetails());
            return productInfo;
        }

        public async Task<ProductInfoDetails> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == id);
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.CommitAsync();
            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == product.productId, selectionProductInfoDetails());
            return productInfo;
        }

        public async Task<ProductInfoDetails> UpdateAsync(UpdateProductDTO productDto)
        {
            var product = _unitOfWork.Products.FirstOrDefault(x => x.productId == productDto.Id);
            product.productName = product.productName;
            product.productDescription = product.productDescription;
            _unitOfWork.Products.Update(product);
            await _unitOfWork.CommitAsync();
            var productInfo = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.productId == product.productId, selectionProductInfoDetails());
            return productInfo;
        }

        public Expression<Func<Product, ProductInfo>> selectionProductInfo()
        {
            return x => new ProductInfo
            {
                Id = x.productId,
                productName = x.productName,
            };
        }

        public Expression<Func<Product, ProductInfoDetails>> selectionProductInfoDetails()
        {
            return x => new ProductInfoDetails
            {
                Id = x.productId,
                productName = x.productName,
                productDescription = x.productDescription
            };
        }

        #endregion Methods
    }
}
