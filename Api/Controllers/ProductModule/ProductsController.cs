using Api.Controllers.ColorModule;
using App.Core;
using App.EF.Consts;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.ColorModule.Contracts.VM;
using App.Shared.Models.General;
using App.Shared.Models.ProductModule.Contracts.DTO;
using App.Shared.Models.ProductModule.Contracts.VM;
using App.Shared.Resources.General;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ProductModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductServices _productServices;
        private readonly ProductValid _productValid;

        #endregion Members

        #region Constructor

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _productServices = new ProductServices(_unitOfWork, _mapper);
            _productValid = new ProductValid(_unitOfWork);
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string? textSearch = null, [FromQuery] PaginationRequest? paginationRequest = null)
        {
            paginationRequest = paginationRequest ?? new PaginationRequest();
            ProductGetAllResponse productGetAllResponse = new();

            var watch = Stopwatch.StartNew();
            try
            {
                var (products, pagination) = await _productServices.GetAllAsync(textSearch, paginationRequest);

                productGetAllResponse = productGetAllResponse.CreateResponseSuccessOrNoContent(products, pagination);
            }
            catch (Exception ex)
            {
                productGetAllResponse = productGetAllResponse.CreateResponseError(GeneralMessages.errorSomthingWrong);
                string message = $"An error occurred in GetAll: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                productGetAllResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(productGetAllResponse);
        }

        [HttpGet("GetProductDetails")]
        public async Task<IActionResult> GetProductDetails([FromQuery] int id)
        {
            ProductGetDetailsResponse productGetDetailsResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productValid.ValidProduct(id);

                if (isValidProduct.Status != EnumStatus.success)
                    productGetDetailsResponse = productGetDetailsResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status);

                var product = await _productServices.GetDetails(id);
                productGetDetailsResponse = productGetDetailsResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status, product);
            }
            catch (Exception ex)
            {
                productGetDetailsResponse = productGetDetailsResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in GetDetails: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                productGetDetailsResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(productGetDetailsResponse);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO productDto)
        {
            ProductAddResponse productAddResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productValid.ValidProductAdd(productDto);
                if (isValidProduct.Status != EnumStatus.success)
                {
                    productAddResponse = productAddResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status);
                }
                else
                {
                    var product = await _productServices.AddAsync(productDto);
                    productAddResponse = productAddResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status, product);
                }
            }
            catch (Exception ex)
            {
                productAddResponse = productAddResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in AddColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                productAddResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(productAddResponse);
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO productDto)
        {
            ProductUpdateResponse productUpdateResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productValid.ValidProductUpdate(productDto);
                if (isValidProduct.Status != EnumStatus.success)
                {
                    productUpdateResponse = productUpdateResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status);
                }
                else
                {
                    var product = await _productServices.UpdateAsync(productDto);
                    productUpdateResponse = productUpdateResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status, product);
                }
            }
            catch (Exception ex)
            {
                productUpdateResponse = productUpdateResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in UpdateColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                productUpdateResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(productUpdateResponse);
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] int id)
        {
            ProductDeleteResponse productDeleteResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productValid.ValidProduct(id);
                if (isValidProduct.Status != EnumStatus.success)
                {
                    productDeleteResponse = productDeleteResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status);
                }
                else
                {
                    var deletedProduct = await _productServices.DeleteAsync(id);
                    productDeleteResponse = productDeleteResponse.CreateResponse(isValidProduct.Message, isValidProduct.Status, deletedProduct);
                }
            }
            catch (Exception ex)
            {
                productDeleteResponse = productDeleteResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in DeleteUnit: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                productDeleteResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(productDeleteResponse);
        }

        #endregion Methods
    }
}
