using App.Shared;
using App.Shared.Interfaces.OnlineStoreModules.Wishlists;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.OnlineStoreModules._02._0_Wishlist.DTO;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Api.Controllers.OnlineStoreModules.Wishlists
{
    internal class WishlistsService : IWishlistsService
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public WishlistsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        private readonly Expression<Func<Wishlist, WishlistInfo>> select = WishlistsAdaptor.SelectExpressionWishlistInfo();

        public async Task<BaseGetDataWithPagnation<WishlistInfo>> GetAllAsync(WishlistSearchDto inputModel)
        {
            var criteria = GenrateCriteria(inputModel);

            var includes = GetIncludes(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.UserWishlists.GetAllAsync(select, criteria, paginationRequest, includes);
        }

        private List<Expression<Func<Wishlist, bool>>> GenrateCriteria(WishlistSearchDto inputModel)
        {
            List<Expression<Func<Wishlist, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x => x.productData.productName.Contains(inputModel.textSearch));
            }

            if (inputModel.userId.HasValue)
                criteria.Add(x => x.userId == inputModel.elemetId.Value);

            return criteria;
        }

        private List<Expression<Func<Wishlist, object>>> GetIncludes(WishlistSearchDto inputModel)
        {
            List<Expression<Func<Wishlist, object>>> includes = [];

            if (inputModel.userDataInclude == true)
                includes.Add(x => x.userData);

            if (inputModel.productDataInclude == true)
                includes.Add(x => x.productData);

            return includes;
        }

        private List<Expression<Func<Wishlist, object>>> GetAllIncludes()
        {
            return GetIncludes(new()
            {
                userDataInclude = true,
                productDataInclude = true,
            });
        }

        public async Task<WishlistInfo> GetDetails(BaseGetDetailsDto inputModel)
        {
            Expression<Func<Wishlist, bool>> criteria = (x) => x.userId == inputModel.elementId;

            var includes = GetAllIncludes();

            var userInfo = await _unitOfWork.UserWishlists.FirstOrDefaultAsync(criteria, select, includes);

            return userInfo;
        }

        public async Task<BaseActionDone<IEnumerable<WishlistInfo>>> Update(WishlistUpdateDto inputModel)
        {

            await _unitOfWork.UserWishlists.AsQueryable()
                .Where(x => x.userId == inputModel.userId)
                .ExecuteDeleteAsync();

            var isDone = await _unitOfWork.CommitAsync();

            List<Wishlist> wishlistsOfUser = MapDtoToWishList(inputModel);

            await _unitOfWork.UserWishlists.AddRangeAsync(wishlistsOfUser);

            isDone = await _unitOfWork.CommitAsync();

            var updatedWishlist = GetAllAsync(new() { userId = inputModel.userId }).Result.Data;

            return BaseActionDone<IEnumerable<WishlistInfo>>.GenrateBaseActionDone(isDone, updatedWishlist);
        }

        private List<Wishlist> MapDtoToWishList(WishlistUpdateDto inputModel)
        {
            var wishlist = new List<Wishlist>();
            foreach (var item in inputModel.withListUpdateItems)
            {
                wishlist.Add(new()
                {
                    userId = inputModel.userId,
                    prodcutId = item.prodcutId,
                    productQuantity = item.productQuantity,
                });
            }
            return wishlist;
        }
        #endregion Methods
    }
}