using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class HoursWorkedDTO
    {
        public long Id { get; set; }
        public DateTime Month { get; set; }
        public string WorkerId { get; set; }
        public long TaskId { get; set; }
        public long Amount { get; set; }
        public virtual WorkerDTO Worker { get; set; }
        public virtual TaskDTO Task { get; set; }
    }
}
