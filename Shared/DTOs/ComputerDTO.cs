using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class ComputerDTO
    {
        public long Id { get; set; }
        public string Model { get; set; }
        [JsonIgnore]
        public virtual WorkerDTO Worker { get; set; }
    }
}
