using System.Reflection;
using Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class MachinesContext : DbContext
    {
        public MachinesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineProduction> MachineProductions { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}