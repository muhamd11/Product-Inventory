using App.Shared.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace App.Shared.Models.AdditionsModules.LogActionsModel.DTO
{
    public class LogActionAddOrUpdateDTO
    {
        public int logActionId { get; set; }
        public int userId { get; set; }
        public string modelName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
        public string oldActionData { get; set; }
        public string newActionData { get; set; }
    }
}