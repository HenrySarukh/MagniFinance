using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniFinanceTest.Application.DTOs
{
    public class SubjectInformation
    {
        public string SubjectName { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public int StudentsCount { get; set; }
        public double AverageGrade { get; set; }
    }
}
