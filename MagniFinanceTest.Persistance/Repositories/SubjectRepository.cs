using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagniFinanceTest.Persistance.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(MagniFinanceDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyList<Subject>> GetSubjectInformation()
        {
            var result = await this.dbContext.Subjects
                .Include(subject => subject.Teacher)
                .Include(subject => subject.Grades)
                .ThenInclude(grade => grade.Student)
                .ToListAsync();

            return result;
        }
    }
}
