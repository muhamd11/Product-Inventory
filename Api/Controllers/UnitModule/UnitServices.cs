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

        public async Task<(IEnumerable<UnitInfo>, Pagination)> GetAllAsync(string? textSearch = null, PaginationRequest? paginationRequest = null)
        {
            Expression<Func<Unit, bool>> criteria = null;
            paginationRequest = paginationRequest ?? new PaginationRequest();

            if (!string.IsNullOrEmpty(textSearch))
                criteria = (x) => EF.Functions.Like(x.Name, $"%{textSearch}%");

            var (units, pagination) = await _unitOfWork.Units.GetAllAsync(selectionUnitInfo(), criteria, paginationRequest);

            return (units, pagination);
        }

        public async Task<UnitInfoDetails> GetDetails(int id)
        {
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.Id == id, selectionUnitInfoDetails());
            return unitInfo;
        }

        public async Task<UnitInfoDetails> AddAsync(AddUnitDTO unitDto)
        {
            var unit = _mapper.Map<Unit>(unitDto);
            await _unitOfWork.Units.AddAsync(unit);
            await _unitOfWork.CommitAsync();
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.Id == unit.Id, selectionUnitInfoDetails());
            return unitInfo;
        }

        public async Task<UnitInfoDetails> DeleteAsync(int id)
        {
            var unit = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.Id == id);
            _unitOfWork.Units.Delete(unit);
            await _unitOfWork.CommitAsync();
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.Id == unit.Id, selectionUnitInfoDetails());
            return unitInfo;
        }

        public async Task<UnitInfoDetails> UpdateAsync(UpdateUnitDTO unitDto)
        {
            var unit = _unitOfWork.Units.FirstOrDefault(x => x.Id == unitDto.Id);
            unit.Name = unitDto.Name;
            unit.Description = unitDto.Description;
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CommitAsync();
            var unitInfo = await _unitOfWork.Units.FirstOrDefaultAsync(x => x.Id == unit.Id, selectionUnitInfoDetails());
            return unitInfo;
        }

        public Expression<Func<Unit, UnitInfo>> selectionUnitInfo()
        {
            return x => new UnitInfo
            {
                Id = x.Id,
                unitName = x.Name,
            };
        }

        public Expression<Func<Unit, UnitInfoDetails>> selectionUnitInfoDetails()
        {
            return x => new UnitInfoDetails
            {
                Id = x.Id,
                unitName = x.Name,
                unitDescription = x.Description
            };
        }

        #endregion Methods
    }
}