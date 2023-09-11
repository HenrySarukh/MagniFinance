using MagniFinanceTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniFinanceTest.Application.DTOs
{
    public class CourseInformation
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseCode { get; set; }
        public int TeachersCount { get; set; }
        public int StudentsCount { get; set; }
        public double AverageGrade { get; set; }
    }
}
