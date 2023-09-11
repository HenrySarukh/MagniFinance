using MagniFinanceTest.Application.DTOs;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Application.Contracts
{
    public interface ITeacherService
    {
        Task<Teacher> GetById(int id);
        Task<IReadOnlyList<Teacher>> ListAll(Func<Teacher, bool> filter = null);
        Task<Teacher> Add(TeacherDTO teacher);
        Task<bool> Update(int id, TeacherDTO teacher);
        Task<bool> Delete(int id);
    }
}
