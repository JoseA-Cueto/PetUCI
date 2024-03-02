using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class Forum
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string comment { get; set; }
        public int idUser { get; set; }
        [ForeignKey("idUser")]
        public User user { get; set; }
    }
}
