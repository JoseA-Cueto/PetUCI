using PetUci.Models;

namespace PetUci.ViewModels
{
    public class RolViewModel
    {
        public int id { get; set; }
        public string nombreRol { get; set; }
        public ICollection<User> usuarios { get; set; }
    }
}
