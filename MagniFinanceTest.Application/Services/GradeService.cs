using AutoMapper;
using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository gradeRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GradeService(
            IGradeRepository gradeRepository,
            IUserRepository userRepository,
            IMapper mapper
            )
        {

            this.gradeRepository = gradeRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Grade> Add(GradeDTO grade)
        {
            if (grade.GradeValue < 0 || grade.GradeValue > 20)
            {
                throw new Exception("Grade must be between 0 and 20!");
            }

            var newGrade = this.mapper.Map<Grade>(grade);
            var user = await this.userRepository.GetById();
            newGrade.CreatedBy = user;
            newGrade.LastModifiedBy = user;

            var result = await this.gradeRepository.Add(newGrade);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var grade = await this.gradeRepository.GetById(id);
            if (grade == null)
            {
                throw new Exception("Grade not found!");
            }

            var result = await this.gradeRepository.Delete(grade);

            return result;
        }

        public async Task<Grade> GetById(int id)
        {
            var result = await this.gradeRepository.GetById(id);

            return result;
        }

        public async Task<IReadOnlyList<Grade>> ListAll(Func<Grade, bool> filter = null)
        {
            var result = await this.gradeRepository.ListAll(filter);

            return result;
        }

        public async Task<bool> Update(int id, GradeDTO grade)
        {
            if (grade.GradeValue < 0 || grade.GradeValue > 20)
            {
                throw new Exception("Grade must be between 0 and 20!");
            }

            var updateGrade = await this.gradeRepository.GetById(id);
            if (updateGrade == null)
            {
                throw new Exception("Grade not found!");
            }

            updateGrade.GradeValue = grade.GradeValue;
            updateGrade.SubjectId = grade.SubjectId;
            updateGrade.StudentId = grade.StudentId;


            var result = await this.gradeRepository.Update(updateGrade);

            if (!result)
            {
                throw new Exception("There was an error while trying to update the grade");
            }

            return result;
        }
    }
}
