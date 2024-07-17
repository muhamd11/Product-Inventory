using App.Shared.Models.Users;
using System;

namespace App.Shared.Models.UsersModule.LogActionsModel.ViewModel
{
    public class LogActionInfo
    {
        public int logActionId { get; set; }
        public BaseUserInfo logUser { get; set; }
        public string ModelName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
    }
}