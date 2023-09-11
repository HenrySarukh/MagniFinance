using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Persistance.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(MagniFinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
