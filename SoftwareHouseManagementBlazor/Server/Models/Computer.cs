using System.ComponentModel.DataAnnotations;

namespace SoftwareHouseManagementBlazor.Server.Models
{
    public class Computer
    {
        public Computer(string nameModel)
        {
            this.Model = nameModel;
        }

        public Computer()
        {

        }
        public long Id { get; set; }
        [Required]
        public string Model { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
