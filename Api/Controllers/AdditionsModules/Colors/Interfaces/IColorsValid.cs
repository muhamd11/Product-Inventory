using Api.Scrutor;
using App.Shared.Models.AdditionsModules.ColorModule.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.Colors.Interfaces
{
    public interface ICategoriesValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidColorId(int colorId);
    }
}