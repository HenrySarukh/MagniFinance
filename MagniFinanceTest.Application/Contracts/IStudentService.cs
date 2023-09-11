using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniFinanceTest.Application.Contracts
{
    public interface IStudentService
    {
        Task<Student> GetById(int id);
        Task<IReadOnlyList<Student>> ListAll(Func<Student, bool> filter = null);
        Task<Student> Add(StudentDTO student);
        Task<bool> Update(int id, StudentDTO student);
        Task<bool> Delete(int id);
        public Task<List<StudentInfromation>> GetStudentsInformation();
    }
}
