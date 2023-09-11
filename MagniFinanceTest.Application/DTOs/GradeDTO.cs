using MagniFinanceTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniFinanceTest.Application.DTOs
{
    public class GradeDTO
    {
        public double GradeValue { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
    }
}
