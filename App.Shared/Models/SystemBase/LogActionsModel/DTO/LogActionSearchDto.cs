using App.Shared.Models.General.BaseRequstModules;

namespace App.Shared.Models.UsersModule.LogActionsModel.DTO
{
    public class LogActionSearchDto : BaseSearchDto
    {
        public string modelName { get; set; }
        public int? userId { get; set; }
    }
}