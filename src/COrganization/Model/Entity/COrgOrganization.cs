
namespace COrganization.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using CAM.Core.Model.Entity;
    using CAM.General.ComplexStruct;

    public class COrgOrganization : BaseEntityNormal, IEntityDataLocker, IEntityExpirationState
    {
        public OrganizationNameStruct MainName { get; set; }
        public OrganizationNameStruct ExtendNameA { get; set; }
        public OrganizationNameStruct ExtendNameB { get; set; }

        [Index(IsClustered = false, IsUnique = false)]
        public long IndustryId { get; set; }

        [Index(IsClustered = false, IsUnique = false)]
        public long ScaleId { get; set; }

        public long BranchCount { get; set; }
        public long UserCount { get; set; }


        public DataLock Locker { get; set; }

        public ExpirationState Expiration { get; set; }
    }
}
