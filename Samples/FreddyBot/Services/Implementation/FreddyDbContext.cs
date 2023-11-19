using FreddyBot.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Services.Implementation;

public class FreddyDbContext : DbContext
{
    public DbSet<SwearJar> SwearJars { get; set; }
    public DbSet<BadPassword> BadPasswords { get; set; }

    public FreddyDbContext(DbContextOptions<FreddyDbContext> options) : base(options) { }
}