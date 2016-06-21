
namespace COrganization.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;
    using CAM.General;

    public class COrgOrganizationFilter : BaseFilter
    {
        public EMExpirationState ExpirationState { get; set; }
        public EMDataLockState LockState { get; set; }
        public long IndustryId { get; set; }
        public long ScaleId { get; set; }

    }
}
