﻿using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Branches.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.PlacesModules.Branches
{
    public static class BranchesAdaptor
    {
        public static Expression<Func<Branch, BranchInfo>> SelectExpressionBranchInfo()
        {
            return branch => new BranchInfo
            {
                branchId = branch.branchId,
                branchContactInfo = branch.branchContactInfo,
            };
        }

        public static Expression<Func<Branch, BranchInfoDetails>> SelectExpressionBranchDetails()
        {
            return branch => new BranchInfoDetails
            {
                branchId = branch.branchId,
                branchContactInfo = branch.branchContactInfo,
                branchContactSocialMedia = branch.branchContactSocialMedia,
                branchOpenAt = branch.branchOpenAt,
                branchCloseAt = branch.branchCloseAt
            };
        }

        public static BranchInfo SelectExpressionBranchInfo(Branch branch)
        {
            return new BranchInfo
            {
                branchId = branch.branchId,
                branchContactInfo = branch.branchContactInfo,
            };
        }

        public static BranchInfoDetails SelectExpressionBranchDetails(Branch branch)
        {
            return new BranchInfoDetails
            {
                branchId = branch.branchId,
                branchContactInfo = branch.branchContactInfo,
                branchContactSocialMedia = branch.branchContactSocialMedia,
                branchOpenAt = branch.branchOpenAt,
                branchCloseAt = branch.branchCloseAt
            };
        }
    }
}