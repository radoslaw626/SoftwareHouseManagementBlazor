using System.ComponentModel.DataAnnotations;

namespace SoftwareHouseManagementBlazor.Shared.Models
{
    public class Computer
    {
        public Computer(string nameModel)
        {
            Model = nameModel;
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
