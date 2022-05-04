using AutoMapper;
using SoftwareHouseManagementBlazor.Shared.DTOs;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Server
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Access,AccessDTO>().ReverseMap();
            CreateMap<Computer,ComputerDTO>().ReverseMap();
            CreateMap<HoursWorked,HoursWorkedDTO>().ReverseMap();
            CreateMap<Position,PositionDTO>().ReverseMap();
            CreateMap<Responsibility,ResponsibilityDTO>().ReverseMap();
            CreateMap<Task,TaskDTO>().ReverseMap();
            CreateMap<Team,TeamDTO>().ReverseMap();
            CreateMap<Worker,WorkerDTO>().ReverseMap();
        }
    }
}
