
namespace COrganization.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;

    public interface ICDepartmentCommand : IBaseInterfaceCommand<DBContextCOrganization>
    {
        long addDepartment(long BranchId, long ParentId, string Name, string NameShort);
        void updateDepartment(long Id, string Name, string NameShort);
        void lockDepartment(long Id, string lockReason);
        void unLockDepartment(long Id);
        void deleteDepartment(long Id);
        void recoverDepartment(long Id);
        void moveDepartmentToLast(long Id);
        void moveDepartmentToNext(long Id);
        void moveDepartmentToTop(long Id);
        void moveDepartmentToBottom(long Id);
        void moveDepartmentToParentNode(long Id, long moveToParentId);
        void addOneUserCountInDepartment(long Id);
        void subtractOneUserCountInDepartment(long Id);

        COrgDepartment readDepartment(long Id);

    }
}
