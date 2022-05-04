using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagementBlazor.Shared.Entities
{
    public class Worker : IdentityUser
    {
        public Worker()
        {
            Teams = new Collection<Team>();
            HoursWorked = new Collection<HoursWorked>();
            Positions = new Collection<Position>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? ComputerId { get; set; }
        public virtual Computer Computer { get; set; }
        public virtual IList<Team> Teams { get; set; }
        public virtual IList<HoursWorked> HoursWorked { get; set; }
        public virtual IList<Position> Positions { get; set; }

    }
}

