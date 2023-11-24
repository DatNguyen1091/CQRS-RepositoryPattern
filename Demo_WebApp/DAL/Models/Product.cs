global using WebApp_DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_DAL.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        [Required]
        public double Price { get; set; }
        [Range(0, 1000)]
        [Required]
        public int Quatity { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
