using App.Shared.Models.Branches;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Branches.Services
{
    public static class BranchesAdaptor
    {
        public static Expression<Func<Branch, BranchInfo>> SelectExpressionBranchInfo()
        {
            return branch => new BranchInfo
            {
                branchId = branch.branchId,
                branchName = branch.branchName,
            };
        }

        public static Expression<Func<Branch, BranchInfoDetails>> SelectExpressionBranchDetails()
        {
            return branch => new BranchInfoDetails
            {
                branchId = branch.branchId,
                branchName = branch.branchName,
                branchAddress = branch.branchAddress,
            };
        }

        public static BranchInfo SelectExpressionBranchInfo(Branch branch)
        {
            return new BranchInfo
            {
                branchId = branch.branchId,
                branchName = branch.branchName,
            };
        }

        public static BranchInfoDetails SelectExpressionBranchDetails(Branch branch)
        {
            return new BranchInfoDetails
            {
                branchId = branch.branchId,
                branchName = branch.branchName,
                branchAddress = branch.branchAddress,
            };
        }
    }
}