using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    public class MachineProduction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MachineProductionId { get; set; }
        public Machine Machine { get; set; }
        public int MachineId { get; set; }

        [Required]
        [DefaultValue(0)]
        public int TotalProduction { get; set; }
    }
}