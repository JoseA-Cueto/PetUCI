using PetUci.Models;

namespace PetUci.ViewModels
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdDisease { get; set; }
        public string DiseaseName { get; set; }
        public Disease Disease { get; set; }
    }
}
