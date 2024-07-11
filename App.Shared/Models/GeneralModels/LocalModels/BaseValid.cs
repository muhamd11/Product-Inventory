﻿using App.Shared.Consts.GeneralModels;

namespace App.Shared.Models.General.LocalModels
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