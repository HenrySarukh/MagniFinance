using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Domain.Contracts
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        public Task<IReadOnlyList<Student>> GetStudentInformation();
    }
}
