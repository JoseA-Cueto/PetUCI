using PetUci.Models;

namespace PetUci.ViewModels
{
    public class ForumViewModel
    {
        public int id { get; set; }
        public string comment { get; set; }
        public int idUser { get; set; }
        public User user { get; set; }
    }
}
