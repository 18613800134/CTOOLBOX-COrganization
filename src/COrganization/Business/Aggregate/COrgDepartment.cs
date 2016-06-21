
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
    using CAM.Core.Business.Rule;

    using Interface;
    using Rule;

    using CAM.Common.Data;
    using CAM.Common.Convert;
    using CAM.Common.Error;


    public partial class Aggregate : ICDepartmentCommand
    {

        public long addDepartment(long BranchId, long ParentId, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgDepartment> res = createRepository<COrgDepartment>();
                COrgDepartment dbObj = COrgDepartmentFactory.createDepartment();

                dbObj.BranchId = BranchId;
                dbObj.Tree.ParentId = ParentId;

                dbObj.NameStruct.Name = Name;
                dbObj.NameStruct.NameShort = NameShort;

                dbObj.Order.Index = createNewOrderIndex<COrgDepartment>("BranchId", dbObj.BranchId, dbObj.Tree.ParentId);
                dbObj.Tree.Level = createNewTreeLevel<COrgDepartment>(dbObj.Tree.ParentId);

                dbObj.addValidationRule(new DepartmentCannotWithOutBranchRule(res, dbObj));

                dbObj.validate();
                res.add(dbObj);

                if (dbObj.Tree.ParentId == 0)
                {
                    addBranchDepartmentCount(dbObj.BranchId, 1);
                }


                commit();

                return dbObj.Id;
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
                return 0;
            }
        }

        public void updateDepartment(long Id, string Name, string NameShort)
        {
            try
            {
                IRepository<COrgDepartment> res = createRepository<COrgDepartment>();
                COrgDepartment dbObj = res.read(m => m.Id == Id);

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

        public void lockDepartment(long Id, string lockReason)
        {
            try
            {
                lockEntity<COrgDepartment>(Id, lockReason);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void unLockDepartment(long Id)
        {
            try
            {
                unLockEntity<COrgDepartment>(Id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteDepartment(long Id)
        {
            try
            {
                IRepository<COrgDepartment> res = createRepository<COrgDepartment>();

                COrgDepartment dbObj = res.read(m => m.Id == Id);
                dbObj.addValidationRule(new TreeModelDeleteCheckRule<COrgDepartment>(res, dbObj));
                dbObj.addValidationRule(new DepartmentCannotDeleteWhenExistsUserRule(res, dbObj));
                dbObj.validate();

                res.delete(typeof(COrgDepartment), Id.ToString());
                if (dbObj.Tree.ParentId == 0)
                {
                    subtractBranchDepartmentCount(dbObj.BranchId, 1);
                }

                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void recoverDepartment(long Id)
        {
            try
            {
                IRepository<COrgDepartment> res = createRepository<COrgDepartment>();
                res.recover(typeof(COrgDepartment), Id.ToString());
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveDepartmentToLast(long Id)
        {
            try
            {
                moveLast<COrgDepartment>(Id, "Tree_ParentId", "BranchId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveDepartmentToNext(long Id)
        {
            try
            {
                moveNext<COrgDepartment>(Id, "Tree_ParentId", "BranchId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveDepartmentToTop(long Id)
        {
            try
            {
                moveToTop<COrgDepartment>(Id, "Tree_ParentId", "BranchId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveDepartmentToBottom(long Id)
        {
            try
            {
                moveToBottom<COrgDepartment>(Id, "Tree_ParentId", "BranchId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void moveDepartmentToParentNode(long Id, long moveToParentId)
        {
            try
            {
                moveToParentNode<COrgDepartment>(Id, moveToParentId, "BranchId");
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void addOneUserCountInDepartment(long Id)
        {
            try
            {
                addDepartmentUserCount(Id, 1);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void subtractOneUserCountInDepartment(long Id)
        {
            try
            {
                subtractDepartmentUserCount(Id, 1);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public COrgDepartment readDepartment(long Id)
        {
            IRepository<COrgDepartment> res = createRepository<COrgDepartment>();
            return res.read(m => m.Id == Id);
        }






        #region 组织架构内计数器功能实现：protected代码，外部无法访问


        protected void addDepartmentUserCount(long Id, long userCount)
        {
            try
            {
                IRepository<COrgDepartment> res = createRepository<COrgDepartment>();
                COrgDepartment dbObj = res.read(m => m.Id == Id);
                addBranchUserCount(dbObj.BranchId, userCount);
                dbObj.UserCount += userCount;
                res.update(dbObj);
                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
        protected void subtractDepartmentUserCount(long Id, long userCount)
        {
            try
            {
                addDepartmentUserCount(Id, -userCount);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }



        #endregion

    }
}
