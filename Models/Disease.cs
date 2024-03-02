using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }    
        public Treatment treatment { get; set; }

    }
}
