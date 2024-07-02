using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Resources.General;
using System.Collections.Generic;
using System.Linq;

public class BaseGetAllResponse<T> : Dictionary<string, object>
{
    public EnumStatus Status { get; set; }
    public string Message { get; set; }
    public decimal ExecutionTimeMilliseconds { get; set; }
    public Pagination Pagination { get; set; }
    public IEnumerable<T> Data { get; set; }

    public BaseGetAllResponse<T> CreateResponseSuccessOrNoContent(IEnumerable<T> data, Pagination pagination, string moduleName)
    {
        if (!data.Any())
        {
            return new BaseGetAllResponse<T>
            {
                Message = GeneralMessages.errorDataNotFound,
                Status = EnumStatus.noContent
            };
        }

        var response = new BaseGetAllResponse<T>
        {
            Message = GeneralMessages.operationSuccess,
            Status = EnumStatus.success,
            Pagination = pagination
        };

        response[nameof(Status)] = response.Status;
        response[nameof(Message)] = response.Message;
        response[nameof(ExecutionTimeMilliseconds)] = response.ExecutionTimeMilliseconds;
        response[nameof(Pagination)] = response.Pagination;
        // Add the data with the module name as the key
        response[moduleName] = data;
  
        return response;
    }

    public BaseGetAllResponse<T> CreateResponseError(string message, EnumStatus enumStatus, string moduleName)
    {
        var response = new BaseGetAllResponse<T>
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
