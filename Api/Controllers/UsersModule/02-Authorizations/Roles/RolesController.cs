using Api.Controllers.Authorizations.Roles.Interfaces;
using App.EF.Consts;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.Authorizations.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<RolesController> _logger;

        private readonly IRoleValid _rolesValid;
        private readonly IRoleServices _rolesServices;

        //paramters
        private readonly string roleInfoData = "roleInfoData";

        private readonly string rolesInfoData = "rolesInfoData";
        private readonly string roleInfoDetails = "roleInfoDetails";

        #endregion Members

        #region Constructor

        public RolesController(IRoleValid rolesValid, IRoleServices rolesServices, ILogger<RolesController> logger)
        {
            _logger = logger;
            _rolesValid = rolesValid;
            _rolesServices = rolesServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetRoleDetails")]
        public async Task<IActionResult> GetRoleDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<RoleInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidRole = _rolesValid.ValidGetDetails(inputModel);
                if (isValidRole.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidRole, roleInfoDetails);
                else
                {
                    var roleDetails = await _rolesServices.GetDetails(inputModel);
                    response = response.CreateResponse(roleDetails, roleInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(roleInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] RoleSearchDto inputModel)
        {
            BaseGetAllResponse<RoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidRole = _rolesValid.ValidGetAll(inputModel);
                if (isValidRole.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidRole, rolesInfoData);
                else
                {
                    var role = await _rolesServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(role, rolesInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(roleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleAddOrUpdateDTO inputModel)
        {
            string roleInfoData = "roleInfoData";
            BaseActionResponse<RoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidRole = _rolesValid.ValidAddOrUpdate(inputModel, false);
                if (isValidRole.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidRole, roleInfoData);
                else
                {
                    var roleData = await _rolesServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(roleData, roleInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(roleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleAddOrUpdateDTO inputModel)
        {
            string roleInfoData = "roleInfoData";
            BaseActionResponse<RoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidRole = _rolesValid.ValidAddOrUpdate(inputModel, true);
                if (isValidRole.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidRole, roleInfoData);
                else
                {
                    var roleData = await _rolesServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(roleData, roleInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(roleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<RoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidRole = _rolesValid.ValidDelete(inputModel);
                if (isValidRole.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidRole, roleInfoData);
                }
                else
                {
                    var deletedRole = await _rolesServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedRole, roleInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(roleInfoData);
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