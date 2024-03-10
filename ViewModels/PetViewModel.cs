namespace PetUci.ViewModels
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string NamePet { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
    }
}
