using App.Shared.Models.General.BaseRequstModules;

namespace App.Shared.Models.AdditionsModules.LogActionsModel.DTO
{
    public class LogActionSearchDto : BaseSearchDto
    {
        public string modelName { get; set; }
        public int? userId { get; set; }
    }
}