using MagniFinanceTest.Domain.Common;

namespace MagniFinanceTest.Domain.Entities
{
    public class Subject : AuditableEntity
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
