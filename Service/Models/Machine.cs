
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class Machine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MachineId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public MachineProduction MachineProduction { get; set; }
    }
}