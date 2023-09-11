using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Domain.Contracts
{
    public interface ISubjectRepository : IAsyncRepository<Subject>
    {
        public Task<IReadOnlyList<Subject>> GetSubjectInformation();
    }
}
