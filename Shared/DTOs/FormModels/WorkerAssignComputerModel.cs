using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareHouseManagementBlazor.Shared.DTOs.FormModels
{
    public class WorkerAssignComputerModel
    {
        public string workerId { get; set; }
        public long computerId { get; set; }
    }
}
