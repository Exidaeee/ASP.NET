using System.ComponentModel.DataAnnotations;

namespace ShopRazor_Temp.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [Range(1, 100, ErrorMessage = "castom error massage")]
        public int DisplayOrder { get; set; }
    }
}
