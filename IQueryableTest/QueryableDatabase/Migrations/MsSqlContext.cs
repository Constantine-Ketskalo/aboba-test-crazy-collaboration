using Microsoft.EntityFrameworkCore;
using QueryableDatabase.Models;

namespace QueryableDatabase.Migrations
{
    public class MsSqlContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Armageddon> Armageddons { get; set; }

        public MsSqlContext(DbContextOptions<MsSqlContext> dbContextOptions) : base(dbContextOptions) { }
    }
}
