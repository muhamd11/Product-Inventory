using Api.Controllers.AdditionsModules.Colors.Interfaces;
using App.EF.Consts;
using App.Shared.Models.AdditionsModules.ColorModule.DTO;
using App.Shared.Models.AdditionsModules.ColorModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.AdditionsModules.Colors
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<ColorsController> _logger;

        private readonly IColorsValid _colorsValid;
        private readonly IColorServices _colorsServices;

        //parmters
        private readonly string colorInfoData = "colorInfoData";

        private readonly string colorsInfoData = "colorsInfoData";
        private readonly string colorInfoDetails = "colorInfoDetails";

        #endregion Members

        #region Constructor

        public ColorsController(IColorsValid colorsValid, IColorServices colorsServices, ILogger<ColorsController> logger)
        {
            _logger = logger;
            _colorsValid = colorsValid;
            _colorsServices = colorsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetColorDetails")]
        public async Task<IActionResult> GetColorDetails([FromQuery] BaseGetDetalisDto inputModel)
        {
            BaseGetDetailsResponse<ColorInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorsValid.ValidGetDetails(inputModel);
                if (isValidColor.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidColor, colorInfoDetails);
                else
                {
                    var colorDetails = await _colorsServices.GetDetails(inputModel);
                    response = response.CreateResponse(colorDetails, colorInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(colorInfoDetails);
                string message = $"An error occurred in GetDetails: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                response.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] ColorSearchDto inputModel)
        {
            BaseGetAllResponse<ColorInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorsValid.ValidGetAll(inputModel);
                if (isValidColor.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidColor, colorsInfoData);
                else
                {
                    var color = await _colorsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(color, colorsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(colorInfoData);
                string message = $"An error occurred in GetDetails: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                response.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddColor")]
        public async Task<IActionResult> AddColor([FromBody] ColorAddOrUpdateDTO inputModel)
        {
            string colorInfoData = "colorInfoData";
            BaseActionResponse<ColorInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorsValid.ValidAddOrUpdate(inputModel, false);
                if (isValidColor.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidColor, colorInfoData);
                else
                {
                    var colorData = await _colorsServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(colorData, colorInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(colorInfoData);
                string message = $"An error occurred in AddColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                response.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateColor")]
        public async Task<IActionResult> UpdateColor([FromBody] ColorAddOrUpdateDTO inputModel)
        {
            string colorInfoData = "colorInfoData";
            BaseActionResponse<ColorInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorsValid.ValidAddOrUpdate(inputModel, true);
                if (isValidColor.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidColor, colorInfoData);
                else
                {
                    var colorData = await _colorsServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(colorData, colorInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(colorInfoData);
                string message = $"An error occurred in UpdateColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                response.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteColor")]
        public async Task<IActionResult> DeleteColor([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<ColorInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorsValid.ValidDelete(inputModel);
                if (isValidColor.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidColor, colorInfoData);
                }
                else
                {
                    var deletedColor = await _colorsServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedColor, colorInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(colorInfoData);
                string message = $"An error occurred in DeleteColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                response.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        #endregion Methods
    }
}