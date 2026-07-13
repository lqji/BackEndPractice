using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace UnivisitySystem.models;


public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int studentId { get; set; } // system generated

    [Required]
    [MaxLength(100)]
    public string fullName { get; set; } // user input

    [Required]
    [MaxLength(150)]
    public string email { get; set; } // user input

    [MaxLength(20)]
    public string phoneNumber { get; set; } // user input

    [Required]
    public DateTime dateOfBirth { get; set; } // user input

    [Required]
    [Range(2000, 2030)]
    public int enrollmentYear { get; set; } // user input

    [Range(0.0, 4.0)]
    public decimal gpa { get; set; } = 0.0m; // default value / calculated

    
    public ICollection<Enrollment> Enrollments { get; set; } // system generated
}
