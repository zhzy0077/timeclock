using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class TimeClockContext : DbContext
{
    public DbSet<Account>? Accounts { get; set; }
    public DbSet<Entry>? Entries { get; set; }

    public TimeClockContext(DbContextOptions<TimeClockContext> options) : base(options)
    {
    }
}