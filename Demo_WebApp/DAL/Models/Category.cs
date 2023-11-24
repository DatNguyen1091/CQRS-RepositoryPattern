
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp_DAL.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }

        [JsonIgnore]
        public virtual List<Product>? Products { get; set; }

    }
}
