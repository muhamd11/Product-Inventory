using Api.Controllers.AdditionsModules.Units.Interfaces;
using App.EF.Consts;
using App.Shared.Models.AdditionsModules.UnitModule.DTO;
using App.Shared.Models.AdditionsModules.UnitModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.AdditionsModules.Units
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<UnitsController> _logger;

        private readonly IUnitsValid _unitsValid;
        private readonly IUnitServices _unitsServices;

        //parmters
        private readonly string unitInfoData = "unitInfoData";

        private readonly string unitsInfoData = "unitsInfoData";
        private readonly string unitInfoDetails = "unitInfoDetails";

        #endregion Members

        #region Constructor

        public UnitsController(IUnitsValid unitsValid, IUnitServices unitsServices, ILogger<UnitsController> logger)
        {
            _logger = logger;
            _unitsValid = unitsValid;
            _unitsServices = unitsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetUnitDetails")]
        public async Task<IActionResult> GetUnitDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<UnitInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitsValid.ValidGetDetails(inputModel);
                if (isValidUnit.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUnit, unitInfoDetails);
                else
                {
                    var unitDetails = await _unitsServices.GetDetails(inputModel);
                    response = response.CreateResponse(unitDetails, unitInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(unitInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] UnitSearchDto inputModel)
        {
            BaseGetAllResponse<UnitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitsValid.ValidGetAll(inputModel);
                if (isValidUnit.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidUnit, unitsInfoData);
                else
                {
                    var unit = await _unitsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(unit, unitsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(unitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddUnit")]
        public async Task<IActionResult> AddUnit([FromBody] UnitAddOrUpdateDTO inputModel)
        {
            string unitInfoData = "unitInfoData";
            BaseActionResponse<UnitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitsValid.ValidAddOrUpdate(inputModel, false);
                if (isValidUnit.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUnit, unitInfoData);
                else
                {
                    var unitData = await _unitsServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(unitData, unitInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(unitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateUnit")]
        public async Task<IActionResult> UpdateUnit([FromBody] UnitAddOrUpdateDTO inputModel)
        {
            string unitInfoData = "unitInfoData";
            BaseActionResponse<UnitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitsValid.ValidAddOrUpdate(inputModel, true);
                if (isValidUnit.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUnit, unitInfoData);
                else
                {
                    var unitData = await _unitsServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(unitData, unitInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(unitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteUnit")]
        public async Task<IActionResult> DeleteUnit([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<UnitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUnit = _unitsValid.ValidDelete(inputModel);
                if (isValidUnit.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidUnit, unitInfoData);
                }
                else
                {
                    var deletedUnit = await _unitsServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedUnit, unitInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(unitInfoData);
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