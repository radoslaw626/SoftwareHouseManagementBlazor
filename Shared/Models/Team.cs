using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoftwareHouseManagementBlazor.Shared.Models
{
    public class Team
    {
        public Team()
        {
            Workers = new Collection<Worker>();
            Accesses = new Collection<Access>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }

        public virtual IList<Worker> Workers { get; set; }
        public virtual IList<Access> Accesses { get; set; }
        public long? TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
