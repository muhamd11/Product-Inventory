using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Shared.Consts.GeneralModels;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.SystemBase.SystemRoleFincations
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemRoleFincationsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<SystemRoleFincationsController> _logger;

        private readonly ISystemRoleFincationsValid _systemRoleFincationsValid;
        private readonly ISystemRoleFincationsService _systemRoleFincationsService;

        //paramters
        private readonly string systemRoleFincationInfoData = "systemRoleFincationInfoData";

        private readonly string systemRoleFincationsInfoData = "systemRoleFincationsInfoData";
        private readonly string systemRoleFincationInfoDetails = "systemRoleFincationInfoDetails";

        #endregion Members

        #region Constructor

        public SystemRoleFincationsController(ISystemRoleFincationsValid systemRoleFincationsValid, ISystemRoleFincationsService systemRoleFincationsService, ILogger<SystemRoleFincationsController> logger)
        {
            _logger = logger;
            _systemRoleFincationsValid = systemRoleFincationsValid;
            _systemRoleFincationsService = systemRoleFincationsService;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetSystemRoleFincationDetails")]
        public async Task<IActionResult> GetSystemRoleFincationDetails([FromQuery] int systemRoleId)
        {
            BaseGetDetailsResponse<List<SystemRoleFincation>> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidSystemRoleFincation = _systemRoleFincationsValid.ValidGetDetails(systemRoleId);
                if (isValidSystemRoleFincation.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidSystemRoleFincation, systemRoleFincationInfoDetails);
                else
                {
                    var systemRoleFincationDetails = await _systemRoleFincationsService.GetDetails(systemRoleId);
                    response = response.CreateResponse(systemRoleFincationDetails, systemRoleFincationInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleFincationInfoDetails);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdatePrivlage")]
        public async Task<IActionResult> UpdatePrivlage([FromBody] SystemRoleFincationDto inputModel)
        {
            string systemRoleFincationInfoData = "systemRoleFincationInfoData";
            BaseActionResponse<List<SystemRoleFincation>> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidSystemRoleFincation = _systemRoleFincationsValid.ValidUpdatePrivlage(inputModel);
                if (isValidSystemRoleFincation.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidSystemRoleFincation, systemRoleFincationInfoData);
                else
                {
                    var systemRoleFincationData = await _systemRoleFincationsService.UpdatePrivilege(inputModel);
                    response = response.CreateResponse(systemRoleFincationData, systemRoleFincationInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleFincationInfoData);
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