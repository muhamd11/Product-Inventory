using App.EF.Consts;

namespace App.Shared.Models.General
{
    public class BaseValid
    {
        public EnumStatus Status { get; set; }
        public string Message { get; set; }

        public static BaseValid createBaseValid(string message, EnumStatus status)
        {
            return new BaseValid
            {
                Status = status,
                Message = message
            };
        }
    }
}