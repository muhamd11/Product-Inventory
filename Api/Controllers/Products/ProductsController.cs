using Api.Controllers.AdditionsModules.Products.Interfaces;
using App.EF.Consts;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.Products;
using App.Shared.Models.Products.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.AdditionsModules.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductValid _productsValid;
        private readonly IProductServices _productsServices;

        //parmters
        private readonly string productInfoData = "productInfoData";

        private readonly string productsInfoData = "productsInfoData";
        private readonly string productInfoDetails = "productInfoDetails";

        #endregion Members

        #region Constructor

        public ProductsController(IProductValid productsValid, IProductServices productsServices, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _productsValid = productsValid;
            _productsServices = productsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetProductDetails")]
        public async Task<IActionResult> GetProductDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<ProductInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productsValid.ValidGetDetails(inputModel);
                if (isValidProduct.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidProduct, productInfoDetails);
                else
                {
                    var productDetails = await _productsServices.GetDetails(inputModel);
                    response = response.CreateResponse(productDetails, productInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productInfoDetails);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] ProductSearchDto inputModel)
        {
            BaseGetAllResponse<ProductInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productsValid.ValidGetAll(inputModel);
                if (isValidProduct.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidProduct, productsInfoData);
                else
                {
                    var product = await _productsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(product, productsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddOrUpdateDTO inputModel)
        {
            string productInfoData = "productInfoData";
            BaseActionResponse<ProductInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productsValid.ValidAddOrUpdate(inputModel, false);
                if (isValidProduct.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidProduct, productInfoData);
                else
                {
                    var productData = await _productsServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(productData, productInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductAddOrUpdateDTO inputModel)
        {
            string productInfoData = "productInfoData";
            BaseActionResponse<ProductInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productsValid.ValidAddOrUpdate(inputModel, true);
                if (isValidProduct.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidProduct, productInfoData);
                else
                {
                    var productData = await _productsServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(productData, productInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<ProductInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProduct = _productsValid.ValidDelete(inputModel);
                if (isValidProduct.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidProduct, productInfoData);
                }
                else
                {
                    var deletedProduct = await _productsServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedProduct, productInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        #endregion Methods
    }
}