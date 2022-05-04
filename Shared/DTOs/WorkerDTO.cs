using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class WorkerDTO : IdentityUser
    {
        public WorkerDTO()
        {
            Teams = new Collection<TeamDTO>();
            HoursWorked = new Collection<HoursWorkedDTO>();
            Positions = new Collection<PositionDTO>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? ComputerId { get; set; }
        public virtual ComputerDTO Computer { get; set; }
        public virtual IList<TeamDTO> Teams { get; set; }
        public virtual IList<HoursWorkedDTO> HoursWorked { get; set; }
        public virtual IList<PositionDTO> Positions { get; set; }
    }
}