using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "castom error massage")]
        public int DisplayOrder { get; set; }
    }
}
