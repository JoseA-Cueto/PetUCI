using PetUci.Models;

namespace PetUci.ViewModels
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correoElectronico { get; set; }
        public string contraseña { get; set; }
        public int rolID { get; set; }
        public Rol rol { get; set; }
        public ICollection<Forum> Forums { get; set; }
    }
}
