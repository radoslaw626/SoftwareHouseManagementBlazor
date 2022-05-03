using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Server.Services;
using SoftwareHouseManagementBlazor.Shared.Models;

namespace SoftwareHouseManagementBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly PositionService _positionService;
        private readonly ApplicationDbContext _context;

        public PositionsController(PositionService positionService, ApplicationDbContext context)
        {
            _positionService=positionService;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Position> Get()
        {
            return _positionService.GetAll();
        }

    }
}
