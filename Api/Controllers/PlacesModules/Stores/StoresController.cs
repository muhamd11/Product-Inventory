using Api.Controllers.PlacesModules.Stores.Interfaces;
using App.EF.Consts;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.PlacesModules.Stores.DTO;
using App.Shared.Models.PlacesModules.Stores.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.PlacesModules.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<StoresController> _logger;

        private readonly IStoreValid _storesValid;
        private readonly IStoreServices _storesServices;

        //parmters
        private readonly string storeInfoData = "storeInfoData";

        private readonly string storesInfoData = "storesInfoData";
        private readonly string storeInfoDetails = "storeInfoDetails";

        #endregion Members

        #region Constructor

        public StoresController(IStoreValid storesValid, IStoreServices storesServices, ILogger<StoresController> logger)
        {
            _logger = logger;
            _storesValid = storesValid;
            _storesServices = storesServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetStoreDetails")]
        public async Task<IActionResult> GetStoreDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<StoreInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidStore = _storesValid.ValidGetDetails(inputModel);
                if (isValidStore.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidStore, storeInfoDetails);
                else
                {
                    var storeDetails = await _storesServices.GetDetails(inputModel);
                    response = response.CreateResponse(storeDetails, storeInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(storeInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] StoreSearchDto inputModel)
        {
            BaseGetAllResponse<StoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidStore = _storesValid.ValidGetAll(inputModel);
                if (isValidStore.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidStore, storesInfoData);
                else
                {
                    var store = await _storesServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(store, storesInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(storeInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddStore")]
        public async Task<IActionResult> AddStore([FromBody] StoreAddOrUpdateDTO inputModel)
        {
            string storeInfoData = "storeInfoData";
            BaseActionResponse<StoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidStore = _storesValid.ValidAddOrUpdate(inputModel, false);
                if (isValidStore.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidStore, storeInfoData);
                else
                {
                    var storeData = await _storesServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(storeData, storeInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(storeInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateStore")]
        public async Task<IActionResult> UpdateStore([FromBody] StoreAddOrUpdateDTO inputModel)
        {
            string storeInfoData = "storeInfoData";
            BaseActionResponse<StoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidStore = _storesValid.ValidAddOrUpdate(inputModel, true);
                if (isValidStore.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidStore, storeInfoData);
                else
                {
                    var storeData = await _storesServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(storeData, storeInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(storeInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteStore")]
        public async Task<IActionResult> DeleteStore([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<StoreInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidStore = _storesValid.ValidDelete(inputModel);
                if (isValidStore.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidStore, storeInfoData);
                }
                else
                {
                    var deletedStore = await _storesServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedStore, storeInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(storeInfoData);
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