using System;
using System.Text.Json.Serialization;
using App.Shared.Models.PlacesModules.Branches;

namespace App.Shared.Models.PlacesModules.Branches.ViewModel
{
    public class BranchInfoDetails : BranchInfo
    {
        [JsonPropertyOrder(3)]
        public BranchContactSocialMedia branchContactSocialMedia { get; set; }

        [JsonPropertyOrder(4)]
        public TimeSpan branchOpenAt { get; set; }

        [JsonPropertyOrder(5)]
        public TimeSpan branchCloseAt { get; set; }
    }
}