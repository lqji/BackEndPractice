using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int courseId { get; set; } // system generated

    [Required]
    [MaxLength(10)]
    public string courseCode { get; set; } // user input

    [Required]
    [MaxLength(150)]
    public string courseTitle { get; set; } // user input

    [Required]
    [Range(1, 6)]
    public int creditHours { get; set; } // user input

    [Required]
    public int departmentId { get; set; } // from list / user input

    public int? instructorId { get; set; } // from list / user input

    [Required]
    [MaxLength(20)]
    public string semesterOffered { get; set; } // user input

  
    
    [ForeignKey("departmentId")]
    public Department Department { get; set; } // system generated

    [ForeignKey("instructorId")]
    public Instructor Instructor { get; set; } // system generated

    public ICollection<Enrollment> Enrollments { get; set; } // system generated
}