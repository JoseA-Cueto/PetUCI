namespace PetUci.Models
{
    public class User
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correoElectronico { get; set; }
        public string contraseña { get; set; }
        public int rolID { get; set; }
        public string rol { get; set; }
        public Rol rolObj { get; set; }
        public ICollection<Forum> Forums { get; set; } 
    }
}
