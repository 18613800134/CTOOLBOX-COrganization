
namespace COrganization.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;

    public class COrgBranchFilter : BaseFilter
    {
        public EMDataLockState LockState { get; set; }
        public long OrganizationId { get; set; }
    }
}
