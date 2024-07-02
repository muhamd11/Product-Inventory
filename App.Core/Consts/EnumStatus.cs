﻿namespace App.EF.Consts
{
    public enum EnumStatus
    {
        success = 200, // success operation
        catchStatus = 500,  // catch
        noContent = 204, // no data
        error = 406, // validation
    }
}