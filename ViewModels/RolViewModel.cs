using PetUci.Models;

namespace PetUci.ViewModels
{
    public class RolViewModel
    {
        public int Id { get; set; }
        public string NombreRol { get; set; }
        public ICollection<User> Usuarios { get; set; }
    }
}
