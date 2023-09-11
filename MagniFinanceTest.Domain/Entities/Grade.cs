using MagniFinanceTest.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MagniFinanceTest.Domain.Entities
{
    public class Grade : AuditableEntity
    {
        public int GradeId { get; set; }
        [Range(0, 20, ErrorMessage = "Grade must be between 0 and 20")]
        public double GradeValue { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
