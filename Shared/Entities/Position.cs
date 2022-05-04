using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoftwareHouseManagementBlazor.Shared.Entities
{
    public class Position
    {
        public Position()
        {
            Workers = new Collection<Worker>();
            Responsibilities = new Collection<Responsibility>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Wage { get; set; }

        public virtual IList<Worker> Workers { get; set; }
        public virtual IList<Responsibility> Responsibilities { get; set; }
    }
}
