using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; } // system generated

        [Required]
        public int UserId { get; set; } // foreign key

        [Required]
        public int ProductId { get; set; } // foreign key

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; } // user input

        [MaxLength(1000)]
        public string Comment { get; set; } // user input

        [Required]
        public DateTime ReviewDate { get; set; } // system generated

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } // system generated

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } // system generated
    }
}