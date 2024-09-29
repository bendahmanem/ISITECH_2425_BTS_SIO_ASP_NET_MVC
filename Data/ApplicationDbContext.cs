using System;
using ASPBookProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Data;

public class ApplicationDbContext : DbContext
{
    // Nous allons creer un dbset pour chaque table de notre base de donnees
    // Dbset est une classe generique qui represente une table dans la base de donnees
    // Elle est responsable du mapping objet-relationnel
    public DbSet<Student> Roster { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
}
