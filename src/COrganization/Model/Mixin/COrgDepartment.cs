
namespace COrganization.Model.Mixin
{
    using System;

    public class CDepartmentMixin
    {
        public long Id { get; set; }
        public string NameStruct_Name { get; set; }
        public long UserCount { get; set; }
        public bool Locker_IsLocked { get; set; }
        public DateTime Locker_LockTime { get; set; }
        public string Locker_LockReason { get; set; }
        public long Tree_ParentId { get; set; }
    }
}
