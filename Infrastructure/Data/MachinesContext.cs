using System.Reflection;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
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
            
           modelBuilder.Entity<MachineProduction>()
            .HasKey(k => k.MachineProductionId);

            modelBuilder.Entity<Machine>()
            .HasOne<MachineProduction>(a => a.MachineProduction)
            .WithOne(b => b.Machine)
            .HasForeignKey<MachineProduction>(b => b.MachineId);
        }
    }
}