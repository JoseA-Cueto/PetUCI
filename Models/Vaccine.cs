using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Vaccine
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public DateTime fecha { get; set; }
    }
}
