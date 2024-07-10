using App.Shared.Models.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.AdditionsModules.LogActionsModel

{
    public class LogAction
    {
        public int logActionId { get; set; }

        [ForeignKey(nameof(logUser))]
        public int userId { get; set; }

        public User logUser { get; set; }
        public string ModelName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
        public string oldActionData { get; set; }
        public string newActionData { get; set; }
    }
}