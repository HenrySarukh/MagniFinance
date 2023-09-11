using MagniFinanceTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniFinanceTest.Application.DTOs
{
    public class StudentInfromation
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string RegistrationNumber { get; set; }
        public List<SubjectRespectiveGrade> SubjectRespectiveGrades { get; set; }
    }

    public class SubjectRespectiveGrade
    {
        public string SubjectName { get; set; }
        public double RespectiveGrade { get; set; }
    }
}
