using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Server.Services;
using SoftwareHouseManagementBlazor.Shared.DTOs;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Server.Controllers
{

    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly PositionService _positionService;
        private readonly ApplicationDbContext _context;

        public PositionController(PositionService positionService, ApplicationDbContext context)
        {
            _positionService=positionService;
            _context = context;
        }

        [Route("api/positions")]
        [HttpGet]
        public IEnumerable<PositionDTO> Get()
        {
            return _positionService.GetAll().ToArray();
        }


    }
}
