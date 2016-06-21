
namespace COrganization.Business.Aggregate
{
    using CAM.Core.Business.Interface;
    using CAM.Core.Business.Aggregate;
    using DBContext;

    public partial class Aggregate : BaseAggregate, IBaseInterfaceCommand<DBContextCOrganization>
    {
        public Aggregate()
        {
            this.dbContext = new DBContextCOrganization();
        }

        public DBContextCOrganization DBContext
        {
            get { return (DBContextCOrganization)this.dbContext; }
        }
    }
}
