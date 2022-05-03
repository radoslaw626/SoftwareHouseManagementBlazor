using System;

namespace SoftwareHouseManagementBlazor.Server.Models
{
    public class HoursWorked
    {
        public long Id { get; set; }
        public DateTime Month { get; set; }
        public string WorkerId { get; set; }
        public long TaskId { get; set; }
        public long Amount { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Task Task { get; set; }
    }
}
