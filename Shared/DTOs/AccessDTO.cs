using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class AccessDTO
    {
        public AccessDTO()
        {
            Teams = new Collection<TeamDTO>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual IList<TeamDTO> Teams { get; set; }
    }
}
