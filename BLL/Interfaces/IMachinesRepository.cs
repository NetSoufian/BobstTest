using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IMachinesRepository : IDisposable
    {        
        Task<IEnumerable<Machine>> GetMachinesAsync();
        Task<Machine> GetMachineAsync(int machineId);
        Task<bool> MachineExistsAsync(int machineId);
        void DeleteMachine(Machine machine);
        Task<int> Save();
    }
}