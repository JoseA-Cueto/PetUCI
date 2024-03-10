using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Rol
    {
        [Key] 
        public int Id { get; set; }
        public string NombreRol { get; set; }
        public ICollection<User> Usuarios { get; set; }
    }
}
