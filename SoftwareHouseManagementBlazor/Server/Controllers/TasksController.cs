using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Worker> _userManager;
        private readonly TeamsService _teamsService;
        private readonly IMapper _mapper;

        public TasksController(ApplicationDbContext context, UserManager<Worker> userManager, TeamsService teamsService, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _teamsService = teamsService;
            _mapper = mapper;
        }

        [Route("api/task/add")]
        [HttpPost]
        public IActionResult AddTask([FromBody] TaskAddModel data)
        {
            var task = new Task()
            {
                Subject = data.taskSubject
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok();
        }

        [Route("api/tasks/assigned/checkfail")]
        [HttpGet]
        public IEnumerable<TaskDTO> Get()
        {
            return _mapper.Map<IEnumerable<TaskDTO>>(_teamsService.GetAllNotAssignedTasks());
        }





    }
}
