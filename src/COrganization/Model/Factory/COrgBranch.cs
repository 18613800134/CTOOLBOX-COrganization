
namespace COrganization.Model.Factory
{
    using CAM.Core.Model.Entity;
    using CAM.General.ComplexStruct;
    using Entity;
    using System;

    public class COrgBranchFactory
    {
        public static COrgBranch createBranch()
        {
            COrgBranch branch = EntityBuilder.build<COrgBranch>();
            branch.OrganizationId = 0;
            branch.NameStruct = new OrganizationNameStruct();
            branch.Locker = DataLockFactory.createUnLockedLock();
            branch.DepartmentCount = 0;
            branch.UserCount = 0;
            return branch;
        }
    }
}
