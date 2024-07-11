using System;

namespace App.Shared.Models.SystemBase.BaseClass
{
    public class BaseEntity
    {
        public bool? isDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}