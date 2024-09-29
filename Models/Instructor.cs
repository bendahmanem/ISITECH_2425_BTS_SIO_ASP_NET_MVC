using System;

namespace ASPBookProject.Models;

public enum Ranks { Adjunct, Instructor, AssistantProfessor, AssociateProfessor, FullProfessor }

public class Instructor
{
    public int InstructorId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsTenured { get; set; }
    public Ranks Rank { get; set; }
    public DateTime HiringDate { get; set; }
}
