using FreddyBot.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Services.Implementation.Database;

public class SwearJarContext : DbContext
{
    public DbSet<SwearJar> SwearJars { get; set; }

    public SwearJarContext(DbContextOptions<SwearJarContext>  options) : base(options)
    {
    }
}