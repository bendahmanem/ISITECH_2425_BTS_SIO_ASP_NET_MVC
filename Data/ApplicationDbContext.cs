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

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Medecin> Medecins => Set<Medecin>();
    public DbSet<Allergie> Allergies => Set<Allergie>();
    public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
    public DbSet<Medicament> Medicaments => Set<Medicament>();
    public DbSet<Antecedent> Antecedents => Set<Antecedent>();


    // Constructeur
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    // Ajout de mock data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
          .HasMany(p => p.Allergies)
          .WithMany(a => a.Patients);

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Antecedents)
            .WithMany(a => a.Patients);

        modelBuilder.Entity<Allergie>()
            .HasMany(a => a.Medicaments)
            .WithMany(m => m.Allergies);

        modelBuilder.Entity<Antecedent>()
            .HasMany(a => a.Medicaments)
            .WithMany(m => m.Antecedents);

        modelBuilder.Entity<Ordonnance>()
            .HasOne(o => o.Patient)
            .WithOne(p => p.Ordonnance)
            .HasForeignKey<Ordonnance>(o => o.PatientId);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasData(
            new Student()
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Doe",
                AdmissionDate = DateTime.Parse("1990-01-01"),
                GPA = 3.5,
                Major = Major.IT,
                IsVeteran = false
            });
        modelBuilder.Entity<Instructor>().HasData(
            new Instructor()
            {
                InstructorId = 1,
                FirstName = "Jane",
                LastName = "Doe",
                IsTenured = true,
                HiringDate = DateTime.Parse("2010-01-01"),
                Rank = Ranks.AssociateProfessor
            },
            new Instructor()
            {
                InstructorId = 2,
                FirstName = "John",
                LastName = "Smith",
                IsTenured = false,
                HiringDate = DateTime.Parse("2015-01-01"),
                Rank = Ranks.Instructor
            },
            new Instructor()
            {
                InstructorId = 3,
                FirstName = "Jane",
                LastName = "Smith",
                IsTenured = true,
                HiringDate = DateTime.Parse("2012-01-01"),
                Rank = Ranks.FullProfessor
            }

            );
    }
}
