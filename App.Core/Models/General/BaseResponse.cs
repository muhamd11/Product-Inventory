using App.EF.Consts;

namespace App.Shared.Models.General
{
    public class BaseResponse
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }
        public decimal ExecutionTimeMilliseconds { get; set; }
    }
}