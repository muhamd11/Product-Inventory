using App.Core;
using App.Shared.Models.ColorModule;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.ColorModule.ViewModel;
using App.Shared.Models.General;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.ColorModule
{
    public class ColorServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ColorServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<(IEnumerable<ColorInfo>, Pagination)> GetAllAsync(string? textSearch = null, PaginationRequest? paginationRequest = null)
        {
            Expression<Func<Color, bool>> criteria = null;
            paginationRequest = paginationRequest ?? new PaginationRequest();

            if (!string.IsNullOrEmpty(textSearch))
                criteria = (x) => EF.Functions.Like(x.Name, $"%{textSearch}%");

            var (Colors, pagination) = await _unitOfWork.Colors.GetAllAsync(selectionColorInfo(), criteria, paginationRequest);

            return (Colors, pagination);
        }

        public async Task<ColorInfoDetails> GetDetails(int id)
        {
            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.Id == id, selectionColorInfoDetails());
            return colorInfo;
        }

        public async Task<ColorInfoDetails> AddAsync(AddColorDTO colorDto)
        {
            var color = _mapper.Map<Color>(colorDto);
            await _unitOfWork.Colors.AddAsync(color);
            await _unitOfWork.CommitAsync();
            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.Id == color.Id, selectionColorInfoDetails());
            return colorInfo;
        }

        public async Task<ColorInfoDetails> DeleteAsync(int id)
        {
            var color = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.Id == id);
            _unitOfWork.Colors.Delete(color);
            await _unitOfWork.CommitAsync();
            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.Id == color.Id, selectionColorInfoDetails());
            return colorInfo;
        }

        public async Task<ColorInfoDetails> UpdateAsync(UpdateColorDTO colorDto)
        {
            var color = _unitOfWork.Colors.FirstOrDefault(x => x.Id == colorDto.Id);
            color.Name = colorDto.Name;
            color.HexCode = colorDto.HexCode;
            _unitOfWork.Colors.Update(color);
            await _unitOfWork.CommitAsync();
            var colorInfo = await _unitOfWork.Colors.FirstOrDefaultAsync(x => x.Id == color.Id, selectionColorInfoDetails());
            return colorInfo;
        }

        public Expression<Func<Color, ColorInfo>> selectionColorInfo()
        {
            return x => new ColorInfo
            {
                Id = x.Id,
                colorName = x.Name,
            };
        }

        public Expression<Func<Color, ColorInfoDetails>> selectionColorInfoDetails()
        {
            return x => new ColorInfoDetails
            {
                Id = x.Id,
                colorName = x.Name,
                colorHexCode = x.HexCode
            };
        }

        #endregion Methods
    }
}