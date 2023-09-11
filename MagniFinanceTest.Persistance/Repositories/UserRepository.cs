using MagniFinanceTest.Domain.Contracts;
using MagniFinanceTest.Domain.Entities;

namespace MagniFinanceTest.Persistance.Repositories
{
    // Not used properly
    public class UserRepository : IUserRepository
    {
        protected readonly MagniFinanceDbContext dbContext;

        public UserRepository(MagniFinanceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetById()
        {
            // Get hardcoded user from Seed
            return await this.dbContext.Users.FindAsync(new Guid("a79fabab-7571-45c7-b2a5-005f68e81912")); 
        }
    }
}
