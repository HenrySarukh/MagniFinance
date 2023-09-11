using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetById();
    }
}
