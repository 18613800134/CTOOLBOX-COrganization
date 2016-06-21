
namespace COrganization.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;
    using CAM.Common.QueryMaker;

    public interface ICOrganizationCommand : IBaseInterfaceCommand<DBContextCOrganization>
    {
        long addOrganization(string Name, string NameShort, long IndustryId, long ScaleId);
        void updateOrganizationMainName(long Id, string Name, string NameShort);
        void updateOrganizationExtendNameA(long Id, string Name, string NameShort);
        void updateOrganizationExtendNameB(long Id, string Name, string NameShort);
        void updateOrganizationInfo(long Id, long IndustryId, long ScaleId);
        void lockOrganization(long Id, string lockReason);
        void unLockOrganization(long Id);
        void delayExpirationByDays(long Id, int Days);

        COrgOrganization readOrganization(long Id);


    }
}
