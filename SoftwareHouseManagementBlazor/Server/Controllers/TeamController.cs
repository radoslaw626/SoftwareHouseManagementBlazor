using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Worker> _userManager;
        private readonly TeamsService _teamsService;
        private readonly IMapper _mapper;

        public TeamController(ApplicationDbContext context, UserManager<Worker> userManager, TeamsService teamsService, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _teamsService = teamsService;
            _mapper = mapper;
        }


        [Route("api/teams/assigned/check")]
        [HttpGet]
        public IEnumerable<TeamDTO> GetAllAssignedTeams()
        {
            return _mapper.Map<IEnumerable<TeamDTO>>(_teamsService.GetAllAssignedTeams().ToArray());
        }

        [Route("api/teams/assigned/checkfail")]
        [HttpGet]
        public IEnumerable<TeamDTO> GetAllNotAssignedTeams()
        {
            return _mapper.Map<IEnumerable<TeamDTO>>(_teamsService.GetAllNotAssignedTeams().ToArray());
        }

        [Route("api/team/assigntask")]
        [HttpPost]
        public IActionResult TeamAssignTask([FromBody] TeamAssignTaskModel data)
        {
            _teamsService.AssignTaskToTeam(data.teamId, data.taskId, data.hours, data.minutes);
            return Ok();
        }

        [Route("api/team/assignworker")]
        [HttpPost]
        public IActionResult TeamAssignTask([FromBody] TeamAssignWorkerModel data)
        {
            _teamsService.AssignWorkerToTeam(data.teamId,data.workerId);
            return Ok();
        }


        [Route("api/team/add")]
        [HttpPost]
        public IActionResult TeamAdd([FromBody] TeamAddModel data)
        {
            _teamsService.AddTeam(data.teamName);
            return Ok();
        }
    }
}
