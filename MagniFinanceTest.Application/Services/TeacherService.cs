using AutoMapper;
using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public TeacherService(
            ITeacherRepository teacherRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Teacher> Add(TeacherDTO teacher)
        {
            var newTeacher = this.mapper.Map<Teacher>(teacher);
            var user = await this.userRepository.GetById();
            newTeacher.CreatedBy = user;
            newTeacher.LastModifiedBy = user;

            var result = await this.teacherRepository.Add(newTeacher);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var grade = await this.teacherRepository.GetById(id);
            if (grade == null)
            {
                throw new Exception("Teacher not found!");
            }

            var result = await this.teacherRepository.Delete(grade);

            return result;
        }

        public async Task<Teacher> GetById(int id)
        {
            var result = await this.teacherRepository.GetById(id);

            return result;
        }

        public async Task<IReadOnlyList<Teacher>> ListAll(Func<Teacher, bool> filter = null)
        {
            var result = await this.teacherRepository.ListAll(filter);

            return result;
        }

        public async Task<bool> Update(int id, TeacherDTO teacher)
        {
            var updateTeacher = await this.teacherRepository.GetById(id);
            if (updateTeacher == null)
            {
                throw new Exception("Teacher not found!");
            }

            updateTeacher.FirstName = teacher.FirstName;
            updateTeacher.LastName = teacher.LastName;
            updateTeacher.Birthday = teacher.Birthday;
            updateTeacher.Salary = teacher.Salary;

            var result = await this.teacherRepository.Update(updateTeacher);

            if (!result)
            {
                throw new Exception("There was an error while trying to update the teacher");
            }

            return result;
        }
    }
}
