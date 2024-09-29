using System;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.Models;

// we can also data annotations to specify the display name of the properties
// of the enum
public enum Ranks { Adjunct, Instructor, [Display(Name = "Assistant Professor")] AssistantProfessor, [Display(Name = "Associate Professor")] AssociateProfessor, [Display(Name = "Full Professor")] FullProfessor }

public class Instructor
{

    [Display(Name = "Instructor ID")]
    public int InstructorId { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Is Tenured")]
    public bool IsTenured { get; set; }

    [Display(Name = "Rank")]
    public Ranks Rank { get; set; }

    [Display(Name = "Hiring Date")]
    [DataType(DataType.Date)]
    public DateTime HiringDate { get; set; }
}
