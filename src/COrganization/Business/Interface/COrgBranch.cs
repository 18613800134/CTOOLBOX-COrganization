
namespace COrganization.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.General;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;

    public interface ICBranchCommand : IBaseInterfaceCommand<DBContextCOrganization>
    {
        long addBranch(long OrganizationId, string Name, string NameShort);
        void updateBranch(long Id, string Name, string NameShort);
        void lockBranch(long Id, string lockReason);
        void unLockBranch(long Id);
        void deleteBranch(long Id);
        void recoverBranch(long Id);
        void moveBranchToLast(long Id);
        void moveBranchToNext(long Id);
        void moveBranchToTop(long Id);
        void moveBranchToBottom(long Id);

        COrgBranch readBranch(long Id);
        IQueryable<COrgBranch> readBranchList(COrgBranchFilter filter);
    }
}
