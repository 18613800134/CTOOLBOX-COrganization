
namespace COrganization.Model.Factory
{
    using CAM.Core.Model.Entity;
    using CAM.General.ComplexStruct;
    using Entity;
    using System;

    public class COrgDepartmentFactory
    {
        public static COrgDepartment createDepartment()
        {
            COrgDepartment department = EntityBuilder.build<COrgDepartment>();
            department.BranchId = 0;
            department.NameStruct = new OrganizationNameStruct();
            department.Locker = DataLockFactory.createUnLockedLock();
            department.UserCount = 0;
            return department;
        }
    }
}
