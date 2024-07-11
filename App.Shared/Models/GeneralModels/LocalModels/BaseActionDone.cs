using App.Shared.Consts.GeneralModels;
using App.Shared.Resources.General;

namespace App.Shared.Models.General.LocalModels
{
    public class BaseActionDone<T>
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static BaseActionDone<T> GenrateBaseActionDone(int countRowEffectInDB, T data)
        {
            return new BaseActionDone<T>()
            {
                Status = countRowEffectInDB > 0 ? EnumStatus.success : EnumStatus.error,
                Message = countRowEffectInDB > 0 ? GeneralMessages.actionSuccess : GeneralMessages.errorActionFailed,
                Data = data,
            };
        }
    }
}