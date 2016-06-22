
namespace COrganization.Model.Mixin
{
    using System;

    public class COrganizationMixin
    {
        public long Id { get; set; }
        public string MainName_Name { get; set; }
        public long BranchCount { get; set; }
        public long UserCount { get; set; }
        public bool Locker_IsLocked { get; set; }
        public DateTime Locker_LockTime { get; set; }
        public string Locker_LockReason { get; set; }
        public int Expiration_ExpirationDays { get; set; }
        public DateTime Expiration_ExpirationTime { get; set; }
        public DateTime Expiration_ActiveTime { get; set; }
        public DateTime Expiration_LastActiveTime { get; set; }
        public DateTime System_GenerateTime { get; set; }
    }
}
