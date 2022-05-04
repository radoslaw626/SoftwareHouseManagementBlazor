using System.ComponentModel.DataAnnotations;

namespace SoftwareHouseManagementBlazor.Shared.Entities
{
    public class Computer
    {
        public long Id { get; set; }
        public string Model { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
