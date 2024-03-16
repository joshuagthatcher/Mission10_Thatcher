using Microsoft.EntityFrameworkCore;

namespace MissionTen_Thatcher.Data;

public class BowlerContext : DbContext
{
    public BowlerContext(DbContextOptions<BowlerContext> options) : base(options) { }

    public DbSet<Bowlers> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; }
}