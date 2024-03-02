using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class Treatment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public int idDisease { get; set; }
        [ForeignKey("idDisease")]
        public Disease disease { get; set; }
    }
}
