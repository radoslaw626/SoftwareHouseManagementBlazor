using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareHouseManagementBlazor.Shared.DTOs.FormModels
{
    public class WorkerAddModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long positionId { get; set; }
    }
}
