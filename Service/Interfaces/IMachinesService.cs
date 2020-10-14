using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Interfaces
{
    public interface IMachinesService
    {
        Task<IEnumerable<Machine>> GetAllMachinesAsync();
        Task<Machine> GetMachineByIdAsync(int machineId);
        Task<int> DeleteMachineAsync(Machine machine);
    }
}