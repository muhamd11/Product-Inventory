using App.Shared.Consts.SystemBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.PlacesModules.Branches
{
    [Table($"{nameof(Branch)}s", Schema = nameof(EnumDatabaseSchema.Places))]
    public class Branch
    {
        public int branchId { get; set; }
        public BranchContactInfo branchContactInfo { get; set; }
        public BranchContactSocialMedia branchContactSocialMedia { get; set; }
        public TimeSpan branchOpenAt { get; set; }
        public TimeSpan branchCloseAt { get; set; }
    }

    [Owned]
    public class BranchContactSocialMedia
    {
        [JsonIgnore] public bool jsutForBuildEF { get; set; }
        public string branchWebsite { get; set; }
        public string facebookLink { get; set; }
        public string twitterLink { get; set; }
        public string instagramLink { get; set; }
        public string linkedinLink { get; set; }
        public string youtubeLink { get; set; }
    }

    [Owned]
    public class BranchContactInfo
    {
        [JsonIgnore] public bool jsutForBuildEF { get; set; }
        public string branchName { get; set; }
        public string branchAddress { get; set; }
        public double branchLatitude { get; set; }
        public double branchLongitude { get; set; }
        public string branchManagerName { get; set; }
        public string branchEmail { get; set; }
        public string branchCountryCodeName { get; set; }
        public string branchCountryCode { get; set; }
        public string branchDailCode { get; set; }
        public string branchPhoneNumber { get; set; }
    }
}