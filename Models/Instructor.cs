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

    [Required(ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Is Tenured")]
    public bool IsTenured { get; set; }

    [Required]
    [Display(Name = "Rank")]
    public Ranks Rank { get; set; }

    [Display(Name = "Hiring Date")]
    [DataType(DataType.Date)]
    public DateTime HiringDate { get; set; }


    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format xxx-xxx-xxxx")]
    [Display(Name = "Office Phone Number")]
    public String? PhoneNumber { get; set; }

    [EmailAddress]
    [Display(Name = "Email Address")]
    public String? EmailAddress { get; set; }

    [Url]
    [Display(Name = "Personal webpage")]
    public String? PersonalUrl { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 5)]
    [Display(Name = "Password (we wont use this in the project)")]
    [DataType(DataType.Password)]
    public String? Password { get; set; }


}
