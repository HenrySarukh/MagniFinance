using MagniFinanceTest.Domain.Common;

namespace MagniFinanceTest.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
