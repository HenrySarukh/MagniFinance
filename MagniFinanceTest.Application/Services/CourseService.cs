using AutoMapper;
using MagniFinanceTest.Application.Contracts;
using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Services
{
    public class CourseService : ICoursesService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CourseService(
            ICourseRepository courseRepository,
            IUserRepository userRepository,
            IMapper mapper
            )
        {

            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Course> Add(CourseDTO course)
        {
            var newCourse = this.mapper.Map<Course>(course);
            var user = await this.userRepository.GetById();
            newCourse.CreatedBy = user;
            newCourse.LastModifiedBy = user;

            var result = await this.courseRepository.Add(newCourse);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var course = await this.courseRepository.GetById(id);
            if (course == null)
            {
                throw new Exception("Course not found!");
            }

            var result = await this.courseRepository.Delete(course);

            return result;
        }

        public async Task<Course> GetById(int id)
        {
            var result = await this.courseRepository.GetById(id);

            return result;
        }

        public async Task<List<CourseInformation>> GetCourseInformation()
        {
            var courseInformations = new List<CourseInformation>();
            var courses = await this.courseRepository.GetCourseInformation();
            foreach (var course in courses)
            {
                var courseInformation = new CourseInformation
                {
                    CourseCode = course.Code,
                    CourseDescription = course.Description,
                    CourseName = course.Name,
                    TeachersCount = course.Subjects?.Select(subjet => subjet.Teacher).Count() ?? 0,
                    AverageGrade = course.Subjects?.Select(subject => subject.Grades?.Select(grade => grade.GradeValue).Average()).Average() ?? 0,
                    StudentsCount = course.Subjects?.SelectMany(subject => subject.Grades)?.Select(grade => grade.StudentId).Distinct().Count() ?? 0
                };
                courseInformations.Add(courseInformation);
            }

            return courseInformations;
        }

        public async Task<IReadOnlyList<Course>> ListAll(Func<Course, bool> filter = null)
        {
            var result = await this.courseRepository.ListAll(filter);

            return result;
        }

        public async Task<bool> Update(int id, CourseDTO course)
        {
            var updateCourse = await this.courseRepository.GetById(id);
            if (updateCourse == null)
            {
                throw new Exception("Course not found!");
            }

            updateCourse.Name = course.Name;
            updateCourse.Description = course.Description;
            updateCourse.Code = course.Code;

            var result = await this.courseRepository.Update(updateCourse);

            if (!result)
            {
                throw new Exception("There was an error while trying to update the course");
            }

            return result;
        }
    }
}
