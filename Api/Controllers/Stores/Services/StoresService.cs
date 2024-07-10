using Api.Controllers.AdditionsModules.Stores.Interfaces;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using App.Shared.Models.Stores;
using App.Shared.Models.Stores.DTO;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Stores.Services
{
    internal class StoreService : IStoreServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<StoreInfo>> GetAllAsync(StoreSearchDto inputModel)
        {
            var select = StoreAdaptor.SelectExpressionStoreInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Stores.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Store, bool>>> GenrateCriteria(StoreSearchDto inputModel)
        {
            List<Expression<Func<Store, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.storeContactInfo.storeName.Contains(inputModel.textSearch)
                || x.storeContactInfo.storeAddress.Contains(inputModel.textSearch));
            }

            if (inputModel.elemetId.HasValue)
                criteria.Add(x => x.storeId == inputModel.elemetId.Value);

            return criteria;
        }

        public async Task<StoreInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = StoreAdaptor.SelectExpressionStoreDetails();

            Expression<Func<Store, bool>> criteria = (x) => x.storeId == inputModel.elementId;

            var storeInfo = await _unitOfWork.Stores.FirstOrDefaultAsync(criteria, select);

            return storeInfo;
        }

        public async Task<BaseActionDone<StoreInfo>> AddOrUpdate(StoreAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var store = _mapper.Map<Store>(inputModel);
            if (isUpdate)
                _unitOfWork.Stores.Update(store);
            else
                await _unitOfWork.Stores.AddAsync(store);

            var isDone = await _unitOfWork.CommitAsync();

            var storeInfo = await _unitOfWork.Stores.FirstOrDefaultAsync(x => x.storeId == store.storeId, StoreAdaptor.SelectExpressionStoreDetails());

            return BaseActionDone<StoreInfo>.GenrateBaseActionDone(isDone, storeInfo);
        }

        public async Task<BaseActionDone<StoreInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var store = await _unitOfWork.Stores.FirstOrDefaultAsync(x => x.storeId == inputModel.elementId);

            _unitOfWork.Stores.Delete(store);

            var isDone = await _unitOfWork.CommitAsync();

            var storeInfo = await _unitOfWork.Stores.FirstOrDefaultAsync(x => x.storeId == store.storeId, StoreAdaptor.SelectExpressionStoreInfo());

            return BaseActionDone<StoreInfo>.GenrateBaseActionDone(isDone, storeInfo);
        }

        #endregion Methods
    }
}