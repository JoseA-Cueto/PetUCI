using PetUci.Models;

namespace PetUci.ViewModels
{
    public class ForumViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
