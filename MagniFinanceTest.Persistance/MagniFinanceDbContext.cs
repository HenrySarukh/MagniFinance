using MagniFinanceTest.Domain.Common;
using MagniFinanceTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagniFinanceTest.Persistance
{
    public class MagniFinanceDbContext : DbContext
    {
        public MagniFinanceDbContext(DbContextOptions<MagniFinanceDbContext> options)
           : base(options)
        {
            // Need for Unit Tests
            if (this.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                this.Database.SetCommandTimeout(TimeSpan.FromHours(1));
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
