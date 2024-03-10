using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
