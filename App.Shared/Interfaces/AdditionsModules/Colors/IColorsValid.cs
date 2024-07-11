using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.AdditionsModules.Shared.Colors.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace App.Shared.Interfaces.AdditionsModules.Colors
{
    public interface IColorsValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidColorId(int colorId);
    }
}