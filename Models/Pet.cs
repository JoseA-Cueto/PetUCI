using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Pet
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string namePet { get; set; }
        public string sexo { get; set; }
        public string raza { get; set; }
    }
}
