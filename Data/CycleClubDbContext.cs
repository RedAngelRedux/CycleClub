using CycleClub.Models;
using Microsoft.EntityFrameworkCore;

namespace CycleClub.Data;

public class CycleClubDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}CycleClubMembershipDb.db");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
}
