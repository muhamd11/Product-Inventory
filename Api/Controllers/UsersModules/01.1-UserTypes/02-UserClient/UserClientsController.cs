using Api.Controllers.UsersModules.Users.Interfaces;
using App.Shared.Consts.GeneralModels;
using App.Shared.Interfaces.UsersModule.UserTypes.UserClient;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule._01._1_UserTypes._01._2_UserClientData.DTO;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.DTO;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.UsersModules.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<UserClientsController> _logger;

        private readonly IUserClientValid _usersValid;
        private readonly IUserClientServices _usersServices;

        //paramters
        private readonly string userInfoData = "userInfoData";

        private readonly string usersInfoData = "usersInfoData";
        private readonly string userInfoDetails = "userInfoDetails";

        #endregion Members

        #region Constructor

        public UserClientsController(IUserClientValid usersValid, IUserClientServices usersServices, ILogger<UserClientsController> logger)
        {
            _logger = logger;
            _usersValid = usersValid;
            _usersServices = usersServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetUserClientDetails")]
        public async Task<IActionResult> GetUserDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<BaseUserInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidGetDetails(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, userInfoDetails);
                else
                {
                    var userDetails = await _usersServices.GetDetails(inputModel);
                    response = response.CreateResponse(userDetails, userInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] UserClientSearchDTO inputModel)
        {
            BaseGetAllResponse<UserClientInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidGetAll(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidUser, usersInfoData);
                else
                {
                    var user = await _usersServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(user, usersInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddUserClient")]
        public async Task<IActionResult> AddUser([FromBody] UserClientAddOrUpdateDTO inputModel)
        {
            string userInfoData = "userInfoData";
            BaseActionResponse<UserClientInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidAddOrUpdate(inputModel, false);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, userInfoData);
                else
                {
                    var userData = await _usersServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(userData, userInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateUserClient")]
        public async Task<IActionResult> UpdateUser([FromBody] UserClientAddOrUpdateDTO inputModel)
        {
            string userInfoData = "userInfoData";
            BaseActionResponse<UserClientInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidAddOrUpdate(inputModel, true);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, userInfoData);
                else
                {
                    var userData = await _usersServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(userData, userInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteUserClient")]
        public async Task<IActionResult> DeleteUser([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<UserClientInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidDelete(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidUser, userInfoData);
                }
                else
                {
                    var deletedUser = await _usersServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedUser, userInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
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