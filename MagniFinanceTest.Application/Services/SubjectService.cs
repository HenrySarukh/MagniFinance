using AutoMapper;
using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public SubjectService(
            ISubjectRepository subjectRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            this.subjectRepository = subjectRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Subject> Add(SubjectDTO subject)
        {
            var newSubject = this.mapper.Map<Subject>(subject);
            var user = await this.userRepository.GetById();
            newSubject.CreatedBy = user;
            newSubject.LastModifiedBy = user;

            var result = await this.subjectRepository.Add(newSubject);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var grade = await this.subjectRepository.GetById(id);
            if (grade == null)
            {
                throw new Exception("Subject not found!");
            }

            var result = await this.subjectRepository.Delete(grade);

            return result;
        }

        public async Task<Subject> GetById(int id)
        {
            var result = await this.subjectRepository.GetById(id);

            return result;
        }

        public async Task<List<SubjectInformation>> GetSubjectsInformation()
        {
            var subjectInformations = new List<SubjectInformation>();
            var subjects = await this.subjectRepository.GetSubjectInformation();

            foreach (var subject in subjects)
            {
                var subjectInformation = new SubjectInformation
                {
                    SubjectName = subject.Name,
                    TeacherFirstName = subject.Teacher.FirstName,
                    TeacherLastName = subject.Teacher.LastName,
                    AverageGrade = subject.Grades?.Select(grade => grade.GradeValue).Average() ?? 0,
                    StudentsCount = subject.Grades?.Select(grade => grade.StudentId).Distinct().Count() ?? 0
                };

                subjectInformations.Add(subjectInformation);
            }
            
            return subjectInformations;
        }

        public async Task<IReadOnlyList<Subject>> ListAll(Func<Subject, bool> filter = null)
        {
            var result = await this.subjectRepository.ListAll(filter);

            return result;
        }

        public async Task<bool> Update(int id, SubjectDTO subject)
        {
            var updateSubject = await this.subjectRepository.GetById(id);
            if (updateSubject == null)
            {
                throw new Exception("Subject not found!");
            }

            updateSubject.Name = subject.Name;
            updateSubject.TeacherId = subject.TeacherId;

            var result = await this.subjectRepository.Update(updateSubject);

            if (!result)
            {
                throw new Exception("There was an error while trying to update the subject");
            }

            return result;
        }
    }
}
