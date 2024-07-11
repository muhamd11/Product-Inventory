using Api.Controllers.PlacesModules.Branches.Interfaces;
using App.EF.Consts;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.PlacesModules.Branches.DTO;
using App.Shared.Models.PlacesModules.Branches.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.PlacesModules.Branches
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<BranchesController> _logger;

        private readonly IBranchesValid _branchsValid;
        private readonly IBranchesService _branchesServices;

        //parmters
        private readonly string branchInfoData = "branchInfoData";

        private readonly string branchesInfoData = "branchesInfoData";
        private readonly string branchInfoDetails = "branchInfoDetails";

        #endregion Members

        #region Constructor

        public BranchesController(IBranchesValid branchesValid, IBranchesService branchesServices, ILogger<BranchesController> logger)
        {
            _logger = logger;
            _branchsValid = branchesValid;
            _branchesServices = branchesServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetBranchDetails")]
        public async Task<IActionResult> GetBranchDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<BranchInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidBranch = _branchsValid.ValidGetDetails(inputModel);
                if (isValidBranch.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidBranch, branchInfoDetails);
                else
                {
                    var branchDetails = await _branchesServices.GetDetails(inputModel);
                    response = response.CreateResponse(branchDetails, branchInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(branchInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] BranchSearchDto inputModel)
        {
            BaseGetAllResponse<BranchInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidBranch = _branchsValid.ValidGetAll(inputModel);
                if (isValidBranch.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidBranch, branchesInfoData);
                else
                {
                    var branch = await _branchesServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(branch, branchesInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(branchInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchAddOrUpdateDTO inputModel)
        {
            string branchInfoData = "branchInfoData";
            BaseActionResponse<BranchInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidBranch = _branchsValid.ValidAddOrUpdate(inputModel, false);
                if (isValidBranch.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidBranch, branchInfoData);
                else
                {
                    var branchData = await _branchesServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(branchData, branchInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(branchInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchAddOrUpdateDTO inputModel)
        {
            string branchInfoData = "branchInfoData";
            BaseActionResponse<BranchInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidBranch = _branchsValid.ValidAddOrUpdate(inputModel, true);
                if (isValidBranch.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidBranch, branchInfoData);
                else
                {
                    var branchData = await _branchesServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(branchData, branchInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(branchInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteBranch")]
        public async Task<IActionResult> DeleteBranch([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<BranchInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidBranch = _branchsValid.ValidDelete(inputModel);
                if (isValidBranch.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidBranch, branchInfoData);
                }
                else
                {
                    var deletedBranch = await _branchesServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedBranch, branchInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(branchInfoData);
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