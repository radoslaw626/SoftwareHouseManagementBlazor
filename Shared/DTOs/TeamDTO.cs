using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Shared.DTOs
{
    public class TeamDTO
    {
        public TeamDTO()
        {
            Workers = new Collection<WorkerDTO>();
            Accesses = new Collection<AccessDTO>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }

        public virtual IList<WorkerDTO> Workers { get; set; }
        public virtual IList<AccessDTO> Accesses { get; set; }
        public long? TaskId { get; set; }
        public virtual TaskDTO Task { get; set; }
    }
}
