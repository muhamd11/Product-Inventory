using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Shared.Consts.GeneralModels;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.UsersModule.LogActionsModel.DTO;
using App.Shared.Models.UsersModule.LogActionsModel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.SystemBase.LogActions
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogActionsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<LogActionsController> _logger;

        private readonly ILogActionsValid _loActionsValid;
        private readonly ILogActionServices _loActionsServices;

        //parmters
        private readonly string loActionInfoData = "loActionInfoData";

        private readonly string loActionsInfoData = "loActionsInfoData";
        private readonly string loActionInfoDetails = "loActionInfoDetails";

        #endregion Members

        #region Constructor

        public LogActionsController(ILogActionsValid loActionsValid, ILogActionServices loActionsServices, ILogger<LogActionsController> logger)
        {
            _logger = logger;
            _loActionsValid = loActionsValid;
            _loActionsServices = loActionsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetLogActionDetails")]
        public async Task<IActionResult> GetLogActionDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<LogActionInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogAction = _loActionsValid.ValidGetDetails(inputModel);
                if (isValidLogAction.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidLogAction, loActionInfoDetails);
                else
                {
                    var loActionDetails = await _loActionsServices.GetDetails(inputModel);
                    response = response.CreateResponse(loActionDetails, loActionInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(loActionInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] LogActionSearchDto inputModel)
        {
            BaseGetAllResponse<LogActionInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogAction = _loActionsValid.ValidGetAll(inputModel);
                if (isValidLogAction.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidLogAction, loActionsInfoData);
                else
                {
                    var loAction = await _loActionsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(loAction, loActionsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(loActionInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        //[HttpPost("AddLogAction")]
        //public async Task<IActionResult> AddLogAction([FromBody] LogActionAddOrUpdateDTO inputModel)
        //{
        //    string loActionInfoData = "loActionInfoData";
        //    BaseActionResponse<LogActionInfo> response = new();
        //    var watch = Stopwatch.StartNew();
        //    try
        //    {
        //        var isValidLogAction = _loActionsValid.ValidAddOrUpdate(inputModel, false);
        //        if (isValidLogAction.Status != EnumStatus.success)
        //            response = response.CreateResponse(isValidLogAction, loActionInfoData);
        //        else
        //        {
        //            var loActionData = await _loActionsServices.AddOrUpdate(inputModel, false);
        //            response = response.CreateResponse(loActionData, loActionInfoData);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = response.CreateResponseCatch(loActionInfoData);
        //        _logger.LogError(ex, ex.Message);
        //    }
        //    finally
        //    {
        //        watch.Stop();
        //        response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
        //    }
        //    return Ok(response);
        //}

        //[HttpPost("UpdateLogAction")]
        //public async Task<IActionResult> UpdateLogAction([FromBody] LogActionAddOrUpdateDTO inputModel)
        //{
        //    string loActionInfoData = "loActionInfoData";
        //    BaseActionResponse<LogActionInfo> response = new();
        //    var watch = Stopwatch.StartNew();
        //    try
        //    {
        //        var isValidLogAction = _loActionsValid.ValidAddOrUpdate(inputModel, true);
        //        if (isValidLogAction.Status != EnumStatus.success)
        //            response = response.CreateResponse(isValidLogAction, loActionInfoData);
        //        else
        //        {
        //            var loActionData = await _loActionsServices.AddOrUpdate(inputModel, true);
        //            response = response.CreateResponse(loActionData, loActionInfoData);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = response.CreateResponseCatch(loActionInfoData);
        //        _logger.LogError(ex, ex.Message);
        //    }
        //    finally
        //    {
        //        watch.Stop();
        //        response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
        //    }
        //    return Ok(response);
        //}

        [HttpPost("DeleteLogAction")]
        public async Task<IActionResult> DeleteLogAction([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<LogActionInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogAction = _loActionsValid.ValidDelete(inputModel);
                if (isValidLogAction.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidLogAction, loActionInfoData);
                }
                else
                {
                    var deletedLogAction = await _loActionsServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedLogAction, loActionInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(loActionInfoData);
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