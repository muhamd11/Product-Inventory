using System;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Branches
{
    public class BranchInfoDetails : BranchInfo
    {
        [JsonPropertyOrder(3)]
        public string branchAddress { get; set; }

        public string branchManagerName { get; set; }

        // TODO: Add branchPhoneNumbers
        public string branchEmail { get; set; }

        public string branchWebsite { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string LinkedInLink { get; set; }
        public string YouTubeLink { get; set; }
        public TimeSpan branchOpenAt { get; set; }
        public TimeSpan branchCloseAt { get; set; }
    }
}