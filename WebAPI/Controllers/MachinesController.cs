using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Service.Interfaces;
using Service.Models;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly IMachinesService _machineService;
        private readonly IMapper _mapper;
        private readonly ILogger<MachinesController> _logger;
        public MachinesController(IMachinesService machineService, IMapper mapper, ILogger<MachinesController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _machineService = machineService ?? throw new ArgumentNullException(nameof(machineService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMachines()
        {
            try
            {
                var machines = await _machineService.GetAllMachinesAsync();

                if (machines == null)
                    return NoContent();

                var machinesToReturn = _mapper.Map<IEnumerable<MachinesToReturnDto>>(machines);

                return Ok(machinesToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception while getting machines", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("machine/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMachine(int id)
        {
            try
            {
            var machine = await _machineService.GetMachineByIdAsync(id);

            if (machine == null)
                return NotFound();

            var machineToReturn = _mapper.Map<MachineToReturnDto>(machine);

            return Ok(machineToReturn);
            }
             catch (Exception ex)
            {
                _logger.LogError($"Exception while getting machine {id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("machine/totalproduction/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMachineTotalProduction(int id)
        {
            try
            {
            var machine = await _machineService.GetMachineByIdAsync(id);

            if (machine == null)
                return NotFound();

            var machineTotalProduction = new MachineProductionToReturnDto { TotalProduction = machine.MachineProduction.TotalProduction };

            return Ok(machineTotalProduction);
            }
             catch (Exception ex)
            {
                _logger.LogError($"Exception while getting total production of machine {id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpDelete("machine/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteMachine(int id)
        {
            try
            {
            var machine = await _machineService.GetMachineByIdAsync(id);

            var deleteResult = await _machineService.DeleteMachineAsync(machine);

            return Ok(deleteResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while deleting machine {id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}