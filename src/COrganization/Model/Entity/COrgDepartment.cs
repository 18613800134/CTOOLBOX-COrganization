
namespace COrganization.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using CAM.Core.Model.Entity;
    using CAM.General.ComplexStruct;

    public class COrgDepartment : BaseEntityTree, IEntityDataLocker
    {
        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long BranchId { get; set; }

        public OrganizationNameStruct NameStruct { get; set; }

        public long UserCount { get; set; }

        public DataLock Locker { get; set; }
    }
}
