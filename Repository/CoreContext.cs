using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Context
{
    public class CoreContext : DbContext
    {
        public DbSet<UserEntity> UserEntity { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}