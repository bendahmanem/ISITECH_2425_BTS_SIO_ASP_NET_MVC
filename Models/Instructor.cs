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

    [Display(Name = "Office Phone Number")]
    public String? PhoneNumber { get; set; }

    [Display(Name = "Email Address")]
    public String? EmailAddress { get; set; }

    [Display(Name = "Personal webpage")]
    public String? PersonalUrl { get; set; }

    [Display(Name = "Password (we wont use this in the project)")]
    [DataType(DataType.Password)]
    public String? Password { get; set; }


}
