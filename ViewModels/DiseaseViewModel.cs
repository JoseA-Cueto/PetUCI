using PetUci.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetUci.ViewModels
{
    public class DiseaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTreatment { get; set; }
        [ForeignKey("IdTreatment")]

        public Treatment Treatment { get; set; }
    }
}
