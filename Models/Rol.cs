using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Rol
    {
        [Key] 
        public int id { get; set; }
        public string nombreRol { get; set; }
        public ICollection<User> usuarios { get; set; }
    }
}
