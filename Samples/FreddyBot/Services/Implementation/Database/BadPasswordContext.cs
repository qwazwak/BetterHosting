using FreddyBot.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Services.Implementation.Database;

public class BadPasswordContext : DbContext
{
    public DbSet<BadPassword> BadPasswords { get; set; }
}