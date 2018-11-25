using LittleCat.ScheduleManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LittleCat.ScheduleManager.Repositories
{
    public class LocalDatabaseContext : DbContext
    {
        public DbSet<ScheduleDbRecord> ScheduleDbRecords { get; set; }

        public LocalDatabaseContext()
        {
            
        }

        public LocalDatabaseContext(DbContextOptions<LocalDatabaseContext> options) : base(options)
        {
        }
    }
}