
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
    using Rule;

    using CAM.Common.Data;
    using CAM.Common.Convert;
    using CAM.Common.Error;


    public partial class Aggregate : ICBranchCommand
    {

        public long addBranch(long OrganizationId, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgBranch> res = createRepository<COrgBranch>();
                COrgBranch dbObj = COrgBranchFactory.createBranch();

                dbObj.OrganizationId = OrganizationId;

                dbObj.NameStruct.Name = Name;
                dbObj.NameStruct.NameShort = NameShort;

                dbObj.addValidationRule(new BranchCannotWithOutOrganizationRule(res, dbObj));

                dbObj.validate();
                res.add(dbObj);

                addOrganizationBranchCount(dbObj.OrganizationId, 1);

                commit();

                return dbObj.Id;
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
                return 0;
            }
        }

        public void updateBranch(long Id, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgBranch> res = createRepository<COrgBranch>();
                COrgBranch dbObj = res.read(m => m.Id == Id);

                dbObj.NameStruct.Name = Name;
                dbObj.NameStruct.NameShort = NameShort;

                dbObj.validate();
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void lockBranch(long Id, string lockReason)
        {
            try
            {
                lockEntity<COrgBranch>(Id, lockReason);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void unLockBranch(long Id)
        {
            try
            {
                unLockEntity<COrgBranch>(Id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteBranch(long Id)
        {
            try
            {
                IRepository<COrgBranch> res = createRepository<COrgBranch>();
                COrgBranch dbObj = res.read(m => m.Id == Id);

                dbObj.addValidationRule(new BranchCannotDeleteWhenExistsDepartmentRule(res, dbObj));
                dbObj.addValidationRule(new BranchCannotDeleteWhenExistsUserRule(res, dbObj));

                dbObj.validate();

                res.delete(typeof(COrgBranch), Id.ToString());
                subtractOrganizationBranchCount(dbObj.OrganizationId, 1);

                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void recoverBranch(long Id)
        {
            try
            {
                IRepository<COrgBranch> res = createRepository<COrgBranch>();
                res.recover(typeof(COrgBranch), Id.ToString());
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveBranchToLast(long Id)
        {
            try
            {
                moveLast<COrgBranch>(Id, "OrganizationId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveBranchToNext(long Id)
        {
            try
            {
                moveNext<COrgBranch>(Id, "OrganizationId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveBranchToTop(long Id)
        {
            try
            {
                moveToTop<COrgBranch>(Id, "OrganizationId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveBranchToBottom(long Id)
        {
            try
            {
                moveToBottom<COrgBranch>(Id, "OrganizationId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public COrgBranch readBranch(long Id)
        {
            IRepository<COrgBranch> res = createRepository<COrgBranch>();
            return res.read(m => m.Id == Id);
        }

        public IQueryable<COrgBranch> readBranchList(COrgBranchFilter filter)
        {
            Expression<Func<COrgBranch, bool>> lambda = FilterToLambdaBuilder.build<COrgBranch, COrgBranchFilter>(filter);

            lambda = FilterToLambdaBuilder.linkLambdaForDataLock<COrgBranch>(lambda, filter.LockState);
            lambda = lambda.And<COrgBranch>(m => m.OrganizationId == filter.OrganizationId);

            IQueryable<COrgBranch> result = getDataByFilter<COrgBranch, COrgBranchFilter>(lambda, ref filter);
            return result;
        }






        #region 组织架构内计数器功能实现：protected代码，外部无法访问


        protected void addBranchUserCount(long Id, long userCount)
        {
            try
            {
                IRepository<COrgBranch> res = createRepository<COrgBranch>();
                COrgBranch dbObj = res.read(m => m.Id == Id);
                addOrganizationUserCount(dbObj.OrganizationId, userCount);
                dbObj.UserCount += userCount;
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
        protected void subtractBranchUserCount(long Id, long userCount)
        {
            try
            {
                addBranchUserCount(Id, -userCount);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        protected void addBranchDepartmentCount(long Id, long departmentCount)
        {
            try
            {
                IRepository<COrgBranch> res = createRepository<COrgBranch>();
                COrgBranch dbObj = res.read(m => m.Id == Id);
                dbObj.DepartmentCount += departmentCount;
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
        protected void subtractBranchDepartmentCount(long Id, long departmentCount)
        {
            try
            {
                addBranchDepartmentCount(Id, -departmentCount);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }


        #endregion

    }
}
