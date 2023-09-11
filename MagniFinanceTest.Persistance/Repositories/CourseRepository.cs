using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagniFinanceTest.Persistance.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(MagniFinanceDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyList<Course>> GetCourseInformation()
        {
            var courses = await this.dbContext.Courses
                .Include(course => course.Subjects)
                .ThenInclude(subject => subject.Teacher)
                .Include(course => course.Subjects)
                .ThenInclude(subject => subject.Grades)
                .Include(course => course.Subjects)
                .ThenInclude(subject => subject.Grades)
                .ThenInclude(grade => grade.Student)
                .ToListAsync();
            
            return courses;
        }
    }
}
