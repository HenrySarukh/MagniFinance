using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagniFinanceTest.Persistance.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(MagniFinanceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Student>> GetStudentInformation()
        {
            var result = await this.dbContext.Students
                .Include(students => students.Grades)
                .ThenInclude(grade => grade.Subject)
                .ToListAsync();

            return result;
        }
    }
}
