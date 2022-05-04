using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Server.Services;
using SoftwareHouseManagementBlazor.Shared.DTOs;
using SoftwareHouseManagementBlazor.Shared.DTOs.FormModels;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Server.Controllers
{
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly WorkersService _workerService;
        private readonly PositionService _positionService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Worker> _userManager;

        public WorkerController(WorkersService workerService, PositionService positionService, ApplicationDbContext context, IMapper mapper, UserManager<Worker> userManager)
        {
            _workerService = workerService;
            _positionService = positionService;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Route("api/workers")]
        [HttpGet]
        public IEnumerable<WorkerDTO> GetWorkers()
        {
            return _mapper.Map<IEnumerable<WorkerDTO>>(_workerService.GetAll().ToArray());
        }


        [Route("api/workers/positions/check")]
        [HttpGet]
        public IEnumerable<WorkerDTO> GetWorkersWithPositions()
        {
            var result = _workerService.GetAllWithPositions().ToArray();
            return _mapper.Map<IEnumerable<WorkerDTO>>(result);
            
        }


        [Route("api/worker/removeassignedpositions")]
        [HttpPost]
        public IActionResult DeleteWorkerPositions([FromBody] string workerId)
        {
            _positionService.DeleteAllAssignedPositions(workerId);
            return Ok();
        }

        [Route("api/worker/assignposition")]
        [HttpPost]
        public IActionResult WorkerAssignPosition ([FromBody] PositionAssignModel data)
        {
            _positionService.AssignPosition(data.workerId,data.positionId);
            return Ok();
        }

        [Route("api/workers/computer/checkfalse")]
        [HttpGet]
        public IEnumerable<WorkerDTO> GetWorkersWithoutComputers()
        {
            var result = _workerService.GetAllWithoutComputer().ToArray();
            return _mapper.Map<IEnumerable<WorkerDTO>>(result);
        }
        [Route("api/workers/computer/check")]
        [HttpGet]
        public IEnumerable<WorkerDTO> GetWorkersWithComputers()
        {
            var result = _workerService.GetAllWithComputers().ToArray();
            return _mapper.Map<IEnumerable<WorkerDTO>>(result);
        }

        [Route("api/worker/removeassignedcomputer")]
        [HttpPost]
        public IActionResult DeleteWorkerComputer([FromBody] string workerId)
        {
            _workerService.DeleteAssignedComputer(workerId);
            return Ok();
        }

        [Route("api/worker/assigncomputer")]
        [HttpPost]
        public IActionResult AssignWorkerComputer([FromBody] WorkerAssignComputerModel data)
        {
            _workerService.AssignComputer(data.workerId, data.computerId);
            return Ok();
        }

        [Route("api/worker/add")]
        [HttpPost]
        public async Task<IActionResult> WorkerAdd([FromBody]WorkerAddModel data)
        {
            var position = _context.Positions
                .FirstOrDefault(x => x.Id == data.positionId);
            var worker = new Worker
            {
                UserName = data.Email,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName
            };
            worker.Positions.Add(position);

            var inserted = await _userManager.CreateAsync(worker, data.PasswordHash);
            if (inserted.Succeeded)
            {
                var result1 = await _userManager.AddToRoleAsync(worker, "Worker");

                return Ok();
            }

            foreach (var error in inserted.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
