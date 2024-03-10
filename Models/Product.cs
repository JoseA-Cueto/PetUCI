using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ImageFiles ImageFile { get; set; }
    }
}
