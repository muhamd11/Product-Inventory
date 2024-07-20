using App.Shared.Consts.GeneralModels;
using App.Shared.Interfaces.OnlineStoreModules.Wishlists;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.OnlineStoreModules._02._0_Wishlist.DTO;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.OnlineStoreModules.Wishlists
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<WishlistsController> _logger;

        private readonly IWishlistsValid _WishlistsValid;
        private readonly IWishlistsService _WishlistsServices;

        //parmters
        private readonly string WishlistInfoData = "WishlistInfoData";

        private readonly string WishlistsInfoData = "WishlistsInfoData";
        private readonly string WishlistInfoDetails = "WishlistInfoDetails";

        #endregion Members

        #region Constructor

        public WishlistsController(IWishlistsValid WishlistsValid, IWishlistsService WishlistsServices, ILogger<WishlistsController> logger)
        {
            _logger = logger;
            _WishlistsValid = WishlistsValid;
            _WishlistsServices = WishlistsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetWishlistDetails")]
        public async Task<IActionResult> GetWishlistDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<WishlistInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidWishlist = _WishlistsValid.ValidGetDetails(inputModel);
                if (isValidWishlist.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidWishlist, WishlistInfoDetails);
                else
                {
                    var WishlistDetails = await _WishlistsServices.GetDetails(inputModel);
                    response = response.CreateResponse(WishlistDetails, WishlistInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(WishlistInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] WishlistSearchDto inputModel)
        {
            BaseGetAllResponse<WishlistInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidWishlist = _WishlistsValid.ValidGetAll(inputModel);
                if (isValidWishlist.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidWishlist, WishlistsInfoData);
                else
                {
                    var Wishlist = await _WishlistsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(Wishlist, WishlistsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(WishlistInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateWishlist")]
        public async Task<IActionResult> UpdateWishlist([FromBody] WishlistUpdateDto inputModel)
        {
            string WishlistInfoData = "WishlistInfoData";
            BaseActionResponse<WishlistInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidWishlist = _WishlistsValid.ValidUpdate(inputModel);
                if (isValidWishlist.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidWishlist, WishlistInfoData);
                else
                {
                    var WishlistData = await _WishlistsServices.Update(inputModel);
                    response = response.CreateResponse(WishlistData, WishlistInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(WishlistInfoData);
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