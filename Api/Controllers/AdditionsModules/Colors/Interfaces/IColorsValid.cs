using Api.Scrutor;
using App.Shared.Models.AdditionsModules.ColorModule.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.Colors.Interfaces
{
    public interface IColorsValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetalisDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidUintId(int colorId);
    }
}