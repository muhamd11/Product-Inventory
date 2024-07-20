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


        public async Task<BaseGetDataWithPagnation<WishlistInfo>> GetAllAsync(WishlistSearchDto inputModel)
        {
            var select = WishlistsAdaptor.SelectExpressionWishlistInfo();

            var criteria = GenrateCriteria(inputModel);

            List<Expression<Func<Wishlist, object>>> includes = [];

            includes.Add(x => x.productData);
            includes.Add(x => x.userData);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.UserWishlists.GetAllAsync(select, criteria, paginationRequest, includes);
        }

        private List<Expression<Func<Wishlist, bool>>> GenrateCriteria(WishlistSearchDto inputModel)
        {
            List<Expression<Func<Wishlist, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.productData.productName.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.userId == inputModel.elemetId.Value);

            return criteria;
        }


        public async Task<WishlistInfo> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = WishlistsAdaptor.SelectExpressionWishlistInfo();

            Expression<Func<Wishlist, bool>> criteria = (x) => x.userId == inputModel.elementId;

            List<Expression<Func<Wishlist, object>>> includes = [];

            includes.Add(x => x.userData);
            includes.Add(x => x.productData);

            var userInfo = await _unitOfWork.UserWishlists.FirstOrDefaultAsync(criteria, select, includes);

            return userInfo;
        }

        public async Task<BaseActionDone<WishlistInfo>> Update(WishlistUpdateDto inputModel)
        {
            var wishlist = new Wishlist();
            
            var productCount = await _unitOfWork.UserWishlists.AsQueryable().Where(x => x.userId == inputModel.userId).CountAsync();

            await _unitOfWork.UserWishlists.AsQueryable().Where(x => x.userId == inputModel.userId).ExecuteDeleteAsync();

            var isDone = await _unitOfWork.CommitAsync();

            foreach (var item in inputModel.withListUpdateItems)
            {
                wishlist.userId = inputModel.userId;
                wishlist.productQuantity = item.productQuantity;
                wishlist.prodcutId = item.prodcutId;
                await _unitOfWork.UserWishlists.AddAsync(wishlist);
                isDone = await _unitOfWork.CommitAsync();
            }


            List<Expression<Func<Wishlist, object>>> includes = [];

            includes.Add(x => x.productData);
            includes.Add(x => x.userData);

            var updatedWishlist = await _unitOfWork.UserWishlists.FirstOrDefaultAsync(x => x.userId == inputModel.userId, z => WishlistsAdaptor.SelectExpressionWishlistInfo(z,productCount), includes);

            return BaseActionDone<WishlistInfo>.GenrateBaseActionDone(isDone, updatedWishlist);
        }



        #endregion Methods
    }
}
