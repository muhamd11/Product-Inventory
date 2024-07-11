using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    public class UserClient : BaseEntity
    {
        public int userClientId { get; set; }
 
    }

}