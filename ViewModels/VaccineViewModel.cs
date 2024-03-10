using PetUci.Models;

namespace PetUci.ViewModels
{
    public class VaccineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPet { get; set; }
        public Pet Pet { get; set; }
    }
}
