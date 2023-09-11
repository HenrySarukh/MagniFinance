using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Contracts
{
    public interface IGradeService
    {
        Task<Grade> GetById(int id);
        Task<IReadOnlyList<Grade>> ListAll(Func<Grade, bool> filter = null);
        Task<Grade> Add(GradeDTO grade);
        Task<bool> Update(int id, GradeDTO grade);
        Task<bool> Delete(int id);
    }
}
