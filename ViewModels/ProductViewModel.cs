namespace PetUci.ViewModels
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
    }
}

