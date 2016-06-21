
namespace COrganization.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using CAM.Core.Model.Entity;
    using CAM.General.ComplexStruct;

    public class COrgBranch : BaseEntityOrder, IEntityDataLocker
    {
        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long OrganizationId { get; set; }

        public OrganizationNameStruct NameStruct { get; set; }

        public long DepartmentCount { get; set; }
        public long UserCount { get; set; }

        public DataLock Locker { get; set; }

    }
}
