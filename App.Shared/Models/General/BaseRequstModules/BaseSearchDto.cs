using App.Shared.Models.General.PaginationModule;

namespace App.Shared.Models.General.BaseRequstModules
{
    public class BaseSearchDto : PaginationRequest
    {
        public int? elemetId { get; set; }
        public string? textSearch { get; set; }
    }
}