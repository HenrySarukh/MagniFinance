using AutoMapper;
using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public StudentService(
            IStudentRepository studentRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Student> Add(StudentDTO student)
        {
            var newStudent = this.mapper.Map<Student>(student);
            var user = await this.userRepository.GetById();
            newStudent.CreatedBy = user;
            newStudent.LastModifiedBy = user;

            var result = await this.studentRepository.Add(newStudent);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var grade = await this.studentRepository.GetById(id);
            if (grade == null)
            {
                throw new Exception("Student not found!");
            }

            var result = await this.studentRepository.Delete(grade);

            return result;
        }

        public async Task<Student> GetById(int id)
        {
            var result = await this.studentRepository.GetById(id);

            return result;
        }

        public async Task<List<StudentInfromation>> GetStudentsInformation()
        {
            var studentInformations = new List<StudentInfromation>();
            var result = await this.studentRepository.GetStudentInformation();

            foreach (var student in result)
            {
                var studentInformation = new StudentInfromation
                {
                    StudentFirstName = student.FirstName,
                    StudentLastName = student.LastName,
                    RegistrationNumber = student.RegistrationNumber,
                    SubjectRespectiveGrades = student.Grades
                    .GroupBy(grade => grade.SubjectId)
                    .Select(group => new SubjectRespectiveGrade
                    {
                        SubjectName = group.Select(grade => grade.Subject.Name).First(),
                        RespectiveGrade = group.Average(grade => grade.GradeValue)
                    }).ToList()
                };

                studentInformations.Add(studentInformation);
            }

            return studentInformations;
        }

        public async Task<IReadOnlyList<Student>> ListAll(Func<Student, bool> filter = null)
        {
            var result = await this.studentRepository.ListAll(filter);

            return result;
        }

        public async Task<bool> Update(int id, StudentDTO student)
        {
            var updateStudent = await this.studentRepository.GetById(id);
            if (updateStudent == null)
            {
                throw new Exception("Student not found!");
            }

            updateStudent.FirstName = student.FirstName;
            updateStudent.LastName = student.LastName;
            updateStudent.Birthday = student.Birthday;
            updateStudent.RegistrationNumber = student.RegistrationNumber;

            var result = await this.studentRepository.Update(updateStudent);

            if (!result)
            {
                throw new Exception("There was an error while trying to update the student");
            }

            return result;
        }
    }
}
