using App.EF.Consts;
using App.Shared.Models.ProductModule.Contracts.VM;
using App.Shared.Resources.General;
using System.Collections.Generic;

namespace App.Shared.Models.General
{
    public class BaseResponse
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }
        public decimal ExecutionTimeMilliseconds { get; set; }

    }
}