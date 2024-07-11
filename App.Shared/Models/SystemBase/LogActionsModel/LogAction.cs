using System;

namespace App.Shared.Models.UsersModule.LogActionsModel

{
    public class LogAction
    {
        public int logActionId { get; set; }
        public int userId { get; set; } // Changed to string to store user identifier
        public string modelName { get; set; }
        public DateTimeOffset actionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
        public string oldData { get; set; }
        public string newData { get; set; }
    }
}