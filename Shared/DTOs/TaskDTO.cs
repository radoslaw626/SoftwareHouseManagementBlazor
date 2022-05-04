using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class TaskDTO
    {
        public TaskDTO()
        {
            HoursWorked = new Collection<HoursWorkedDTO>();
        }
        public long Id { get; set; }
        public string Subject { get; set; }
        public long AssignedHours { get; set; }
        public long WorkedHours { get; set; }
        [JsonIgnore]
        public virtual TeamDTO Team { get; set; }
        public virtual WorkerDTO Worker { get; set; }
        public virtual IList<HoursWorkedDTO> HoursWorked { get; set; }
    }
}
