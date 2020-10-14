using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;
using Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class MachinesRepository : IMachinesRepository
    {
        private readonly MachinesContext _context;
        public MachinesRepository(MachinesContext machinesContext) 
        {
            _context = machinesContext ?? throw new ArgumentNullException(nameof(machinesContext));
        }

        public async Task<IEnumerable<Machine>> GetMachinesAsync()
        {
           return await _context.Machines.Include(m => m.MachineProduction).ToListAsync();
        }

        public async Task<Machine> GetMachineAsync(int machineId)
        {
            return await _context.Machines.Include(m => m.MachineProduction)
            .FirstOrDefaultAsync(m => m.MachineId == machineId);
        }

        public async Task<bool> MachineExistsAsync(int machineId)
        {
            return await _context.Machines.AnyAsync(m => m.MachineId == machineId);
        }
        
        public void DeleteMachine(Machine machine)
        {
            _context.Machines.Remove(machine);
        }

         public async Task<int> Save()
        {
            return  await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}