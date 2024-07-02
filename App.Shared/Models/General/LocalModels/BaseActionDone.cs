using App.EF.Consts;
using App.Shared.Resources.General;

namespace App.Shared.Models.General.LocalModels
{
    public class BaseActionDone<T>
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static BaseActionDone<T> GenrateBaseActionDone(int countRowEffectinDB, T data)
        {
            return new BaseActionDone<T>()
            {
                Status = countRowEffectinDB > 0 ? EnumStatus.success : EnumStatus.error,
                //TODO Action Failed Message And action sucsess
                Message = countRowEffectinDB > 0 ? GeneralMessages.deleteSuccess : GeneralMessages.deleteFailed,
                Data = data,
            };
        }
    }
}