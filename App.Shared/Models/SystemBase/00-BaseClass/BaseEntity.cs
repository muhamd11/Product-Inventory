using System;

namespace App.Shared.Models.SystemBase.BaseClass
{
    public class BaseEntity
    {
        public bool? isDeleted { get; set; }
        public DateTimeOffset createdDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? updatedDate { get; set; }
    }
}