using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Vaccine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPet { get; set; }
        public Pet Pet { get; set; }
    }
}
