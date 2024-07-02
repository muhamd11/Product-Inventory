using App.Core;
using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Models.UnitModule.Contracts.DTO;
using App.Shared.Models.UnitModule.Contracts.VM;
using App.Shared.Resources.General;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.UnitModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitsController> _logger;
        private readonly UnitServices _unitServices;
        private readonly UnitValid _unitValid;

        #endregion Members

        #region Constructor

        public UnitsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UnitsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _unitServices = new UnitServices(_unitOfWork, _mapper);
            _unitValid = new UnitValid(_unitOfWork);
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string? textSearch = null, [FromQuery] PaginationRequest? paginationRequest = null)
        {
            paginationRequest = paginationRequest ?? new PaginationRequest();
            UnitGetAllResponse unitGetAllResponse = new();

            var watch = Stopwatch.StartNew();
            try
            {
                var (units, pagination) = await _unitServices.GetAllAsync(textSearch, paginationRequest);

                unitGetAllResponse = unitGetAllResponse.CreateResponseSuccessOrNoContent(units, pagination);
            }
            catch (Exception ex)
            {
                unitGetAllResponse = unitGetAllResponse.CreateResponseError(GeneralMessages.errorSomthingWrong);
                string message = $"An error occurred in GetAll: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                unitGetAllResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(unitGetAllResponse);
        }

        [HttpGet("GetUnitDetails")]
        public async Task<IActionResult> GetUnitDetails([FromQuery] int id)
        {
            UnitGetDetailsResponse unitGetDetailsResponse = new UnitGetDetailsResponse();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitValid.ValidUnit(id);

                if (isValidUnit.Status != EnumStatus.success)
                    unitGetDetailsResponse = unitGetDetailsResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status);

                var unit = await _unitServices.GetDetails(id);
                unitGetDetailsResponse = unitGetDetailsResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status, unit);
            }
            catch (Exception ex)
            {
                unitGetDetailsResponse = unitGetDetailsResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in GetDetails: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                unitGetDetailsResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(unitGetDetailsResponse);
        }

        [HttpPost("AddUnit")]
        public async Task<IActionResult> AddUnit([FromBody] AddUnitDTO unitDto)
        {
            UnitAddResponse unitAddResponse = new UnitAddResponse();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitValid.ValidUnitAdd(unitDto);
                if (isValidUnit.Status != EnumStatus.success)
                {
                    unitAddResponse = unitAddResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status);
                }
                else
                {
                    var unit = await _unitServices.AddAsync(unitDto);
                    unitAddResponse = unitAddResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status, unit);
                }
            }
            catch (Exception ex)
            {
                unitAddResponse = unitAddResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in AddUnit: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                unitAddResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(unitAddResponse);
        }

        [HttpPost("UpdateUnit")]
        public async Task<IActionResult> UpdateUnit([FromBody] UpdateUnitDTO unitDto)
        {
            UnitUpdateResponse unitUpdateResponse = new UnitUpdateResponse();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitValid.ValidUnitUpdate(unitDto);
                if (isValidUnit.Status != EnumStatus.success)
                {
                    unitUpdateResponse = unitUpdateResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status);
                }
                else
                {
                    var unit = await _unitServices.UpdateAsync(unitDto);
                    unitUpdateResponse = unitUpdateResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status, unit);
                }
            }
            catch (Exception ex)
            {
                unitUpdateResponse = unitUpdateResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in UpdateUnit: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                unitUpdateResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(unitUpdateResponse);
        }

        [HttpPost("DeleteUnit")]
        public async Task<IActionResult> DeleteUnit([FromQuery] int id)
        {
            UnitDeleteResponse unitDeleteResponse = new UnitDeleteResponse();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitValid.ValidUnit(id);
                if (isValidUnit.Status != EnumStatus.success)
                {
                    unitDeleteResponse = unitDeleteResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status);
                }
                else
                {
                    var deletedUnit = await _unitServices.DeleteAsync(id);
                    unitDeleteResponse = unitDeleteResponse.CreateResponse(isValidUnit.Message, isValidUnit.Status, deletedUnit);
                }
            }
            catch (Exception ex)
            {
                unitDeleteResponse = unitDeleteResponse.CreateResponse(GeneralMessages.errorSomthingWrong, EnumStatus.catchStatus);
                string message = $"An error occurred in DeleteUnit: {ex.Message}";
                _logger.LogError(ex, message);
            }
            finally
            {
                watch.Stop();
                unitDeleteResponse.ExecutionTimeMilliseconds = watch.ElapsedMilliseconds;
            }
            return Ok(unitDeleteResponse);
        }

        #endregion Methods
    }
}