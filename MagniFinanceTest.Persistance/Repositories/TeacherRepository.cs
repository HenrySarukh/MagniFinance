using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Persistance.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(MagniFinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
