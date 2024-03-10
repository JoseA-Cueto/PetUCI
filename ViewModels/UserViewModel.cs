using PetUci.Models;

namespace PetUci.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
        public string Rol { get; set; }
        public ICollection<Forum> Forums { get; set; }
    }
}
