
namespace COrganization.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;
    using CAM.General;

    public class COrgDepartmentFilter : BaseFilter
    {
        public EMDataLockState LockState { get; set; }
        public long BranchId { get; set; }
        public long ParentId { get; set; }
    }
}
