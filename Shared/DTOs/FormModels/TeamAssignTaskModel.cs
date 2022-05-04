using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareHouseManagementBlazor.Shared.DTOs.FormModels
{
    public class TeamAssignTaskModel
    {
        public long teamId { get; set; }
        public long taskId { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
    }
}
