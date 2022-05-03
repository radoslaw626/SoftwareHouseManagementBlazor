using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoftwareHouseManagementBlazor.Server.Models
{
    public class Access
    {
        public Access()
        {
            Teams = new Collection<Team>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Team> Teams { get; set; }
    }
}
