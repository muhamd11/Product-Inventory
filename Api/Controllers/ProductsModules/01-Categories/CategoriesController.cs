using Api.Controllers.ProductsModules.Categories.Interfaces;
using App.EF.Consts;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.ProductsModules.Categories.DTO;
using App.Shared.Models.ProductsModules.Categories.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ProductsModules.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<CategoriesController> _logger;

        private readonly ICategoriesValid _categoriesValid;
        private readonly ICategoryServices _categoriesServices;

        //paramters
        private readonly string categoryInfoData = "categoryInfoData";

        private readonly string categoriesInfoData = "categorysInfoData";
        private readonly string categoryInfoDetails = "categoryInfoDetails";

        #endregion Members

        #region Constructor

        public CategoriesController(ICategoriesValid categorysValid, ICategoryServices categorysServices, ILogger<CategoriesController> logger)
        {
            _logger = logger;
            _categoriesValid = categorysValid;
            _categoriesServices = categorysServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetCategoryDetails")]
        public async Task<IActionResult> GetCategoryDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<CategoryInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidCategory = _categoriesValid.ValidGetDetails(inputModel);
                if (isValidCategory.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidCategory, categoryInfoDetails);
                else
                {
                    var categoryDetails = await _categoriesServices.GetDetails(inputModel);
                    response = response.CreateResponse(categoryDetails, categoryInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(categoryInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] CategorySearchDto inputModel)
        {
            BaseGetAllResponse<CategoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidCategory = _categoriesValid.ValidGetAll(inputModel);
                if (isValidCategory.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidCategory, categoriesInfoData);
                else
                {
                    var category = await _categoriesServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(category, categoriesInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(categoryInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryAddOrUpdateDTO inputModel)
        {
            string categoryInfoData = "categoryInfoData";
            BaseActionResponse<CategoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidCategory = _categoriesValid.ValidAddOrUpdate(inputModel, false);
                if (isValidCategory.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidCategory, categoryInfoData);
                else
                {
                    var categoryData = await _categoriesServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(categoryData, categoryInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(categoryInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryAddOrUpdateDTO inputModel)
        {
            string categoryInfoData = "categoryInfoData";
            BaseActionResponse<CategoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidCategory = _categoriesValid.ValidAddOrUpdate(inputModel, true);
                if (isValidCategory.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidCategory, categoryInfoData);
                else
                {
                    var categoryData = await _categoriesServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(categoryData, categoryInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(categoryInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<CategoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidCategory = _categoriesValid.ValidDelete(inputModel);
                if (isValidCategory.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidCategory, categoryInfoData);
                }
                else
                {
                    var deletedCategory = await _categoriesServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedCategory, categoryInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(categoryInfoData);
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