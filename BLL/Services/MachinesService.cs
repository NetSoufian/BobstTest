using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class MachinesService : IMachinesService
    {
        private readonly IMachinesRepository _repo;
        public MachinesService(IMachinesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            var machines = await _repo.GetMachinesAsync();

            return machines;
        }

        public async Task<Machine> GetMachineByIdAsync(int machineId)
        {
            var machineExists = await _repo.MachineExistsAsync(machineId);
            
            if (!machineExists)
                return null;

            var machine = await _repo.GetMachineAsync(machineId);

            return machine;
        }

        public async Task<int> DeleteMachineAsync(Machine machine)
        {
            var deleteResult = 0;

            if (machine == null)
                return deleteResult;

            _repo.DeleteMachine(machine);
            await _repo.Save();
            deleteResult = 1;

            return deleteResult;
        }


    }
}