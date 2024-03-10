using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    
        public int IdTreatment { get; set; }
        [ForeignKey("IdTreatment")]
        public Treatment Treatment { get; set; }


    }
}
