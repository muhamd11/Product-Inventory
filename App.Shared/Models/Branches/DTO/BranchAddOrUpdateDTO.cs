using System;

namespace App.Shared.Models.Branches.DTO
{
    public class BranchAddOrUpdateDTO
    {
        public int branchId { get; set; }
        public BranchContactInfo branchContactInfo { get; set; }
        public BranchContactSocialMedia branchContactSocialMedia { get; set; }
        public TimeSpan branchOpenAt { get; set; }
        public TimeSpan branchCloseAt { get; set; }
    }
}