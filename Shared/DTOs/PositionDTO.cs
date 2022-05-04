using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class PositionDTO
    {
        public PositionDTO()
        {
            Workers = new Collection<WorkerDTO>();
            Responsibilities = new Collection<ResponsibilityDTO>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Wage { get; set; }

        public virtual IList<WorkerDTO> Workers { get; set; }
        public virtual IList<ResponsibilityDTO> Responsibilities { get; set; }
    }
}
