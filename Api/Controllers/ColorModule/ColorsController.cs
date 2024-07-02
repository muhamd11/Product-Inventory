using App.Core;
using App.EF.Consts;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.ColorModule.Contracts.VM;
using App.Shared.Models.General;
using App.Shared.Resources.General;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ColorModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ColorsController> _logger;
        private readonly ColorServices _colorServices;
        private readonly ColorValid _colorValid;

        #endregion Members

        #region Constructor

        public ColorsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ColorsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _colorServices = new ColorServices(_unitOfWork, _mapper);
            _colorValid = new ColorValid(_unitOfWork);
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string? textSearch = null, [FromQuery] PaginationRequest? paginationRequest = null)
        {
            paginationRequest = paginationRequest ?? new PaginationRequest();
            ColorGetAllResponse colorGetAllResponse = new();

            var watch = Stopwatch.StartNew();
            try
            {
                var (colors, pagination) = await _colorServices.GetAllAsync(textSearch, paginationRequest);

                colorGetAllResponse = colorGetAllResponse.CreateResponseSuccessOrNoContent(colors, pagination);
            }
            catch (Exception ex)
            {
                colorGetAllResponse = colorGetAllResponse.CreateResponseError(GeneralMessages.errorSomthingWrong);
                string message = $"An error occurred in GetAll: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                colorGetAllResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(colorGetAllResponse);
        }

        [HttpGet("GetColorDetails")]
        public async Task<IActionResult> GetUnitDetails([FromQuery] int id)
        {
            ColorGetDetailsResponse colorGetDetailsResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorValid.ValidColor(id);

                if (isValidColor.Status != EnumStatus.success)
                    colorGetDetailsResponse = colorGetDetailsResponse.CreateResponse(isValidColor.Message, isValidColor.Status);

                var color = await _colorServices.GetDetails(id);
                colorGetDetailsResponse = colorGetDetailsResponse.CreateResponse(isValidColor.Message, isValidColor.Status, color);
            }
            catch (Exception ex)
            {
                colorGetDetailsResponse = colorGetDetailsResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in GetDetails: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                colorGetDetailsResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(colorGetDetailsResponse);
        }

        [HttpPost("AddColor")]
        public async Task<IActionResult> AddUnit([FromBody] AddColorDTO colorDto)
        {
            ColorAddResponse colorAddResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorValid.ValidColorAdd(colorDto);
                if (isValidColor.Status != EnumStatus.success)
                {
                    colorAddResponse = colorAddResponse.CreateResponse(isValidColor.Message, isValidColor.Status);
                }
                else
                {
                    var color = await _colorServices.AddAsync(colorDto);
                    colorAddResponse = colorAddResponse.CreateResponse(isValidColor.Message, isValidColor.Status, color);
                }
            }
            catch (Exception ex)
            {
                colorAddResponse = colorAddResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in AddColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                colorAddResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(colorAddResponse);
        }

        [HttpPost("UpdateColor")]
        public async Task<IActionResult> UpdateUnit([FromBody] UpdateColorDTO colorDto)
        {
            ColorUpdateResponse colorUpdateResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorValid.ValidColorUpdate(colorDto);
                if (isValidColor.Status != EnumStatus.success)
                {
                    colorUpdateResponse = colorUpdateResponse.CreateResponse(isValidColor.Message, isValidColor.Status);
                }
                else
                {
                    var color = await _colorServices.UpdateAsync(colorDto);
                    colorUpdateResponse = colorUpdateResponse.CreateResponse(isValidColor.Message, isValidColor.Status, color);
                }
            }
            catch (Exception ex)
            {
                colorUpdateResponse = colorUpdateResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in UpdateColor: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                colorUpdateResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(colorUpdateResponse);
        }

        [HttpPost("DeleteColor")]
        public async Task<IActionResult> DeleteUnit([FromQuery] int id)
        {
            ColorDeleteResponse colorDeleteResponse = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidColor = _colorValid.ValidColor(id);
                if (isValidColor.Status != EnumStatus.success)
                {
                    colorDeleteResponse = colorDeleteResponse.CreateResponse(isValidColor.Message, isValidColor.Status);
                }
                else
                {
                    var deletedColor = await _colorServices.DeleteAsync(id);
                    colorDeleteResponse = colorDeleteResponse.CreateResponse(isValidColor.Message, isValidColor.Status, deletedColor);
                }
            }
            catch (Exception ex)
            {
                colorDeleteResponse = colorDeleteResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in DeleteUnit: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                colorDeleteResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(colorDeleteResponse);
        }

        #endregion Methods
    }
}