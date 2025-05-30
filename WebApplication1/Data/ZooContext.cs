using Microsoft.EntityFrameworkCore;
using ZooApi.Data.Entities;
using ZooApi.Models;

namespace ZooApi.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) 
        {
        }

        public DbSet<AnimalEntity> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZooContext).Assembly);
        }
    }
}
