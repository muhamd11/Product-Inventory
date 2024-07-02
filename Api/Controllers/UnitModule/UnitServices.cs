using App.Core;
using App.Core.Models.UnitModule;
using App.Shared.Models.General;
using App.Shared.Models.UnitModule.Contracts.DTO;
using App.Shared.Models.UnitModule.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.UnitModule
{
    public class UnitServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UnitServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<(IEnumerable<UnitInfo> data, Pagination pagination)> GetAllAsync(string? textSearch = null, PaginationRequest? paginationRequest = null)
        {
            Expression<Func<Unit, bool>> criteria = null;
            paginationRequest = paginationRequest ?? new PaginationRequest();

            if (!string.IsNullOrEmpty(textSearch))
                criteria = (x) => EF.Functions.Like(x.unitName, $"%{textSearch}%");

            var (units, pagination) = await _unitOfWork.Units.GetAllAsync(selectionUnitInfo(), criteria, paginationRequest);

            return (units, pagination);
        }

        public async Task<UnitInfoDetails> GetDetails(int id)
        {
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == id, selectionUnitInfoDetails());
            return unitInfo;
        }

        public async Task<UnitInfoDetails> AddAsync(AddUnitDTO unitDto)
        {
            var unit = _mapper.Map<Unit>(unitDto);
            await _unitOfWork.Units.AddAsync(unit);
            await _unitOfWork.CommitAsync();
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == unit.unitId, selectionUnitInfoDetails());
            return unitInfo;
        }

        public async Task<UnitInfoDetails> DeleteAsync(int id)
        {
            var unit = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == id);
            _unitOfWork.Units.Delete(unit);
            await _unitOfWork.CommitAsync();
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == unit.unitId, selectionUnitInfoDetails());
            return unitInfo;
        }

        public async Task<UnitInfoDetails> UpdateAsync(UpdateUnitDTO unitDto)
        {
            var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitId == unitDto.Id);
            unit.unitName = unitDto.Name;
            unit.unitDescription = unitDto.Description;
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CommitAsync();
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.unitId == unit.unitId, selectionUnitInfoDetails());
            return unitInfo;
        }

        public Expression<Func<Unit, UnitInfo>> selectionUnitInfo()
        {
            return x => new UnitInfo
            {
                Id = x.unitId,
                unitName = x.unitName,
            };
        }

        public Expression<Func<Unit, UnitInfoDetails>> selectionUnitInfoDetails()
        {
            return x => new UnitInfoDetails
            {
                Id = x.unitId,
                unitName = x.unitName,
                unitDescription = x.unitDescription
            };
        }

        #endregion Methods
    }
}