using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareHouseManagementBlazor.Server.Services;
using SoftwareHouseManagementBlazor.Shared.DTOs;

namespace SoftwareHouseManagementBlazor.Server.Controllers
{
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly ComputersService _computerService;
        private readonly IMapper _mapper;

        public ComputerController(ComputersService computerService, IMapper mapper)
        {
            _computerService = computerService;
            _mapper = mapper;
        }

        [Route("api/computers")]
        [HttpGet]
        public IEnumerable<ComputerDTO> Get()
        {
            return _mapper.Map<IEnumerable<ComputerDTO>>(_computerService.GetAll().ToArray());
        }
        [Route("api/computers/worker/checkfalse")]
        [HttpGet]
        public IEnumerable<ComputerDTO> GetComputersWithoutWorkers()
        {
            return _mapper.Map<IEnumerable<ComputerDTO>>(_computerService.GetAllWithoutWorker().ToArray());
        }



    }
}
