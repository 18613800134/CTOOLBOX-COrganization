
namespace COrganization.Business.DBContext
{
    using System.Data.Entity;
    using CAM.Common.Data;
    using Model.Entity;

    public class DBContextCOrganization : BaseDBContext<DBContextCOrganization>
    {
        public IDbSet<COrgOrganization> COrgOrganization { get; set; }
        public IDbSet<COrgBranch> COrgBranch { get; set; }
        public IDbSet<COrgDepartment> COrgDepartment { get; set; }

    }
}
