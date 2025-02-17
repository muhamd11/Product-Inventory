﻿using System;

namespace App.Shared.Models.UsersModule.LogActionsModel.DTO
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