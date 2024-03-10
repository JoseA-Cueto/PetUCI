using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }    
        public int IdDisease { get; set; }
        [ForeignKey("IdDisease")]
        public Disease Disease { get; set; }


    }
}
