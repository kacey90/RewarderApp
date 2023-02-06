using Microsoft.EntityFrameworkCore;
using Rewarder.Domain.Vouchers;

namespace Rewarder.Infrastructure.Database;
internal class RewarderDbContext : DbContext
{
    public RewarderDbContext(DbContextOptions<RewarderDbContext> options) : base(options)
    {
    }

    public DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("RewarderDB");
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(RewarderDbContext).Assembly);
    //}
}
