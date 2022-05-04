using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class ResponsibilityDTO
    {
        public ResponsibilityDTO()
        {
            Positions = new Collection<PositionDTO>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual IList<PositionDTO> Positions { get; set; }
    }
}
