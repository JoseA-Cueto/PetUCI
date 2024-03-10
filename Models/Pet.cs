using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NamePet { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public ImageFiles ImageFile { get; set; }
    }
}
