using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetUci.Models
{
    public class ImageFiles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContentType { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string PhysicalPath { get; set; }
        public int Size { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set;}
    }
}
