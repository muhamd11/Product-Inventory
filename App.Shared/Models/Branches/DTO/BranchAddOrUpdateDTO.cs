using System;

namespace App.Shared.Models.Branches.DTO
{
    public class BranchAddOrUpdateDTO
    {
        public int branchId { get; set; }
        public string branchName { get; set; }
        public string branchAddress { get; set; }
        public string branchCity { get; set; }
        public string branchCountry { get; set; }
        public double branchLatitude { get; set; }
        public double branchLongitude { get; set; }
        public string branchManagerName { get; set; }

        // TODO: Add branchPhoneNumbers
        public string branchEmail { get; set; }

        public string branchWebsite { get; set; }
        public string facebookLink { get; set; }
        public string twitterLink { get; set; }
        public string instagramLink { get; set; }
        public string linkedinLink { get; set; }
        public string youtubeLink { get; set; }
        public TimeSpan branchOpenAt { get; set; }
        public TimeSpan branchCloseAt { get; set; }
    }
}