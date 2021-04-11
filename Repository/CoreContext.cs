using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class CoreContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }
    }
}