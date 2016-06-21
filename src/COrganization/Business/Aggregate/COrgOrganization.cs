
namespace COrganization.Business.Aggregate
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity.SqlServer;
    using System.Collections.Generic;

    using Model.Entity;
    using Model.Factory;
    using Model.Filter;

    using CAM.Core.Model.Entity;
    using CAM.Core.Business.Interface;
    using CAM.Core.Business.Aggregate;

    using Interface;

    using CAM.Common.Data;
    using CAM.Common.Convert;
    using CAM.Common.Error;
    using CAM.Common.QueryMaker;

    using CAM.General;

    public partial class Aggregate : ICOrganizationCommand
    {

        public long addOrganization(string Name, string NameShort, long IndustryId, long ScaleId)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = COrgOrganizationFactory.createOrganization();
                
                dbObj.MainName.Name = Name;
                dbObj.MainName.NameShort = NameShort;

                dbObj.IndustryId = IndustryId;
                dbObj.ScaleId = ScaleId;

                dbObj.validate();
                res.add(dbObj);
                commit();

                return dbObj.Id;
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
                return 0;
            }
        }

        public void updateOrganizationMainName(long Id, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = res.read(m => m.Id == Id);

                dbObj.MainName.Name = Name;
                dbObj.MainName.NameShort = NameShort;

                dbObj.validate();
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateOrganizationExtendNameA(long Id, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = res.read(m => m.Id == Id);

                dbObj.ExtendNameA.Name = Name;
                dbObj.ExtendNameA.NameShort = NameShort;

                dbObj.validate();
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateOrganizationExtendNameB(long Id, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = res.read(m => m.Id == Id);

                dbObj.ExtendNameB.Name = Name;
                dbObj.ExtendNameB.NameShort = NameShort;

                dbObj.validate();
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateOrganizationInfo(long Id, long IndustryId, long ScaleId)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = res.read(m => m.Id == Id);

                dbObj.IndustryId = IndustryId;
                dbObj.ScaleId = ScaleId;

                dbObj.validate();
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void lockOrganization(long Id, string lockReason)
        {
            try
            {
                lockEntity<COrgOrganization>(Id, lockReason);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void unLockOrganization(long Id)
        {
            try
            {
                unLockEntity<COrgOrganization>(Id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void delayExpirationByDays(long Id, int Days)
        {
            try
            {
                delayEntityExpirationByDays<COrgOrganization>(Id, Days);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public COrgOrganization readOrganization(long Id)
        {
            IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
            return res.read(m => m.Id == Id);
        }






        #region 组织架构内计数器功能实现：protected代码，外部无法访问


        protected void addOrganizationUserCount(long Id, long userCount)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = res.read(m => m.Id == Id);
                dbObj.UserCount += userCount;
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
        protected void subtractOrganizationUserCount(long Id, long userCount)
        {
            try
            {
                addOrganizationUserCount(Id, -userCount);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        protected void addOrganizationBranchCount(long Id, long branchCount)
        {
            try
            {
                IRepository<COrgOrganization> res = createRepository<COrgOrganization>();
                COrgOrganization dbObj = res.read(m => m.Id == Id);
                dbObj.BranchCount += branchCount;
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
        protected void subtractOrganizationBranchCount(long Id, long branchCount)
        {
            try
            {
                addOrganizationBranchCount(Id, -branchCount);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }


        #endregion




    }
}
