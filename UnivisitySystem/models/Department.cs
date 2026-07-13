using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int departmentId { get; set; } // system generated

    [Required]
    [MaxLength(100)]
    public string departmentName { get; set; } // user input

    [MaxLength(50)]
    public string building { get; set; } // user input

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Budget must be greater than or equal to 0")]
    public decimal budget { get; set; } // user input

    public int? headInstructorId { get; set; } // from list / user input

    
    
    [ForeignKey("headInstructorId")]
    public Instructor HeadInstructor { get; set; } // system generated

    public ICollection<Course> Courses { get; set; } // system generated
}