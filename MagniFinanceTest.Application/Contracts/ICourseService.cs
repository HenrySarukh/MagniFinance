using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Contracts
{
    public interface ICoursesService
    {
        Task<Course> GetById(int id);
        Task<IReadOnlyList<Course>> ListAll(Func<Course, bool> filter = null);
        Task<Course> Add(CourseDTO course);
        Task<bool> Update(int id, CourseDTO course);
        Task<bool> Delete(int id);
        Task<List<CourseInformation>> GetCourseInformation();
    }
}
