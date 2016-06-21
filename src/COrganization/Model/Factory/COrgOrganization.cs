
namespace COrganization.Model.Factory
{
    using CAM.Core.Model.Entity;
    using CAM.General.ComplexStruct;
    using Entity;
    using System;

    public class COrgOrganizationFactory
    {
        public static COrgOrganization createOrganization()
        {
            COrgOrganization organization = EntityBuilder.build<COrgOrganization>();
            organization.MainName = new OrganizationNameStruct();
            organization.ExtendNameA = new OrganizationNameStruct();
            organization.ExtendNameB = new OrganizationNameStruct();
            organization.IndustryId = 0;
            organization.ScaleId = 0;
            organization.Locker = DataLockFactory.createUnLockedLock();
            organization.BranchCount = 0;
            organization.UserCount = 0;

            /*
             * 这里是默认创建企业信息的有效期天数
             * 目前是初始化为永久有效的
             * 上线前调整成为根据配置文件设置，初始化为有效期为指定天数的模式
             */
            organization.Expiration = ExpirationStateFactory.createExpirationStateForever();

            return organization;
        }
    }
}
