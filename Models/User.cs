using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
        [ForeignKey("RolId")]
        public Rol RolObj { get; set; }
        public string Rol { get; set; }
        public ICollection<Forum> Forums { get; set; }
    }
}
