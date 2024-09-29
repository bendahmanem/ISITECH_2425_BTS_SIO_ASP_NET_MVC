using System;
using ASPBookProject.Models;

namespace ASPBookProject.Services.FakeDataService;

public class FakeDataService : IFakeDataService
{
    public List<Instructor> InstructorsList { get; }

    public FakeDataService() // constructor
    {
        InstructorsList = new List<Instructor>()
    {
        new Instructor()
    {
        InstructorId = 100,
            FirstName = "Maegan", LastName = "Borer",
            IsTenured = false, HiringDate = DateTime.Parse("2018-08-15"),
            Rank = Ranks.AssistantProfessor},
        new Instructor()
    {
        InstructorId = 200,
            FirstName = "Antonietta ", LastName = "Emmerich",
            IsTenured = true, HiringDate = DateTime.Parse("2022-08-15"),
            Rank = Ranks.AssociateProfessor},
        new Instructor()
    {
        InstructorId = 300,
            FirstName = "Antonietta", LastName = "Lesch",
            IsTenured = false, HiringDate = DateTime.Parse("2015-01-09"),
            Rank = Ranks.FullProfessor},
        new Instructor()
    {
        InstructorId = 400,
            FirstName = "Anjali", LastName = "Jakubowski",
            IsTenured = true, HiringDate = DateTime.Parse("2016-01-10"),
            Rank = Ranks.Adjunct}
};
    }
}
