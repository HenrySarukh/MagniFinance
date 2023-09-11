using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Domain.Common
{
    public class AuditableEntity
    {
        public Guid? CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedById { get; set; }
        public User LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
