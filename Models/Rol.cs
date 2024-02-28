namespace PetUci.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string nombreRol { get; set; }
        public ICollection<User> usuarios { get; set; }
    }
}
