namespace PetUci.ViewModels
{
    public class PetViewModel
    {
        public int id { get; set; }
        public string namePet { get; set; }
        public string sexo { get; set; }
        public string raza { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
    }
}
