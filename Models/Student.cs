using System;

namespace ASPBookProject.Models;

public enum Major { CS, IT, MATH, OTHER }

public class Student
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public bool IsVeteran { get; set; }

    public DateTime AdmissionDate { get; set; }
    public double GPA { get; set; }

    public Major Major { get; set; }
}
