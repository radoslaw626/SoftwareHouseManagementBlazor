using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoftwareHouseManagementBlazor.Shared.Models
{
    public class Responsibilities
    {
        public Responsibilities()
        {
            Positions = new Collection<Position>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Position> Positions { get; set; }
    }
}
