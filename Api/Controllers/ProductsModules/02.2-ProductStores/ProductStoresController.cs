using Api.Controllers.ProductsModules.ProductStores.Interfaces;
using App.EF.Consts;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.ProductStores;
using App.Shared.Models.ProductStores.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ProductsModules.ProductStores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStoresController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<ProductStoresController> _logger;

        private readonly IProductStoresValid _productStoresValid;
        private readonly IProductStoreServices _productStoresServices;

        //parmters
        private readonly string productProductInfoData = "productProductInfoData";

        private readonly string productProductsInfoData = "productProductsInfoData";
        private readonly string productProductInfoDetails = "productProductInfoDetails";

        #endregion Members

        #region Constructor

        public ProductStoresController(IProductStoresValid productStoresValid, IProductStoreServices productStoresServices, ILogger<ProductStoresController> logger)
        {
            _logger = logger;
            _productStoresValid = productStoresValid;
            _productStoresServices = productStoresServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetProductStoreDetails")]
        public async Task<IActionResult> GetProductStoreDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<ProductStoreInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProductProduct = _productStoresValid.ValidGetDetails(inputModel);
                if (isValidProductProduct.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidProductProduct, productProductInfoDetails);
                else
                {
                    var productProductDetails = await _productStoresServices.GetDetails(inputModel);
                    response = response.CreateResponse(productProductDetails, productProductInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productProductInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] ProductStoreSearchDTO inputModel)
        {
            BaseGetAllResponse<ProductStoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProductProduct = _productStoresValid.ValidGetAll(inputModel);
                if (isValidProductProduct.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidProductProduct, productProductsInfoData);
                else
                {
                    var productProduct = await _productStoresServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(productProduct, productProductsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productProductInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddProductStore")]
        public async Task<IActionResult> AddProductStore([FromBody] ProductStoreAddOrUpdateDTO inputModel)
        {
            string productProductInfoData = "productProductInfoData";
            BaseActionResponse<ProductStoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProductProduct = _productStoresValid.ValidAddOrUpdate(inputModel, false);
                if (isValidProductProduct.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidProductProduct, productProductInfoData);
                else
                {
                    var productProductData = await _productStoresServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(productProductData, productProductInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productProductInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateProductStore")]
        public async Task<IActionResult> UpdateProductStore([FromBody] ProductStoreAddOrUpdateDTO inputModel)
        {
            string productProductInfoData = "productProductInfoData";
            BaseActionResponse<ProductStoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProductProduct = _productStoresValid.ValidAddOrUpdate(inputModel, true);
                if (isValidProductProduct.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidProductProduct, productProductInfoData);
                else
                {
                    var productProductData = await _productStoresServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(productProductData, productProductInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productProductInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteProductStore")]
        public async Task<IActionResult> DeleteProductStore([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<ProductStoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidProductProduct = _productStoresValid.ValidDelete(inputModel);
                if (isValidProductProduct.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidProductProduct, productProductInfoData);
                }
                else
                {
                    var deletedProductProduct = await _productStoresServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedProductProduct, productProductInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(productProductInfoData);
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