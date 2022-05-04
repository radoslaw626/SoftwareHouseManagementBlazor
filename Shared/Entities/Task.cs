using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoftwareHouseManagementBlazor.Shared.Entities
{
    public class Task
    {
        public Task()
        {
            HoursWorked = new Collection<HoursWorked>();
        }
        public long Id { get; set; }
        public string Subject { get; set; }
        public long AssignedHours { get; set; }
        public long WorkedHours { get; set; }

        public virtual Team Team { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual IList<HoursWorked> HoursWorked { get; set; }
    }
}
