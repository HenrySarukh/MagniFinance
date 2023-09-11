using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Contracts
{
    public interface ISubjectService
    {
        Task<Subject> GetById(int id);
        Task<IReadOnlyList<Subject>> ListAll(Func<Subject, bool> filter = null);
        Task<Subject> Add(SubjectDTO subject);
        Task<bool> Update(int id, SubjectDTO subject);
        Task<bool> Delete(int id);
        public Task<List<SubjectInformation>> GetSubjectsInformation();
    }
}
