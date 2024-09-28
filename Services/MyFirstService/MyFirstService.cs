using System;

namespace ASPBookProject.Services.MyFirstService;

public interface IMyFirstService
{
    string MyMethod();
}

public class MyFirstService : IMyFirstService
{
    public string MyMethod()
    {
        return $"hash of the current instance of my service: {this.GetHashCode()}";
    }
}
