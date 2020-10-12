using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BLL.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class MachinesContextSeed
    {
          public static async Task SeedAsync(MachinesContext context, ILoggerFactory loggerFactory)
        {
              try
            {
                // var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.Machines.Any())
                {
                    var machinesData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/Machines.json");

                    var machines = JsonSerializer.Deserialize<List<Machine>>(machinesData);

                    foreach (var machine in machines)
                    {
                        context.Machines.Add(machine);
                    }
                  
                }

                if (!context.MachineProductions.Any())
                {
                    var machineProductionsData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/MachineProductions.json");

                    var machineProductions = JsonSerializer.Deserialize<List<MachineProduction>>(machineProductionsData);

                    foreach (var machineProduction in machineProductions)
                    {
                        context.MachineProductions.Add(machineProduction);
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MachinesContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}