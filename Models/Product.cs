namespace PetUci.Models
{
    public class Product
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public ImageFiles ImageFile { get; set; }
    }
}
