using System;
using ASPBookProject.Models;

namespace ASPBookProject.Services.FakeDataService;

public interface IFakeDataService
{
    List<Instructor> InstructorsList { get; }
}
