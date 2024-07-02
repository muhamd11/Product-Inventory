using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Resources.General;
using System.Collections.Generic;
using System.Linq;

public class BaseGetDetailsResponse<T> : Dictionary<string, object>
{
    public EnumStatus Status { get; set; }
    public string Message { get; set; }
    public decimal ExecutionTimeMilliseconds { get; set; }
    public T Data { get; set; }

    public BaseGetDetailsResponse<T> CreateResponseSuccessOrNoContent(T data, string moduleName)
    {
        if (data == null)
        {
            return new BaseGetDetailsResponse<T>
            {
                Message = GeneralMessages.errorDataNotFound,
                Status = EnumStatus.noContent
            };
        }

        var response = new BaseGetDetailsResponse<T>
        {
            Message = GeneralMessages.operationSuccess,
            Status = EnumStatus.success,
        };

        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = data;

        return response;
    }

    public BaseGetDetailsResponse<T> CreateResponseError(string message, EnumStatus enumStatus, string moduleName)
    {
        var response = new BaseGetDetailsResponse<T>
        {
            Message = message,
            Status = enumStatus,
        };

        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        // Add the data with the module name as the key
        response[moduleName] = null;
        return response;
    }
}
