using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // system generated

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } // user input

        [MaxLength(500)]
        public string Description { get; set; } // user input

        [MaxLength(300)]
        public string ImageUrl { get; set; } // user input

        // Navigation Properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>(); // system generated
    }
}