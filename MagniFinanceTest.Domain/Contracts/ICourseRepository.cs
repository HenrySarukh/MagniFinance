using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Domain.Contracts
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
        public Task<IReadOnlyList<Course>> GetCourseInformation();
    }
}
