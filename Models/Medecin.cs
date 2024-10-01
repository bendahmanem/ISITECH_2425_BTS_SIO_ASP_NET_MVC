using System;

namespace ASPBookProject.Models;

public class Medecin
{
    public int MedecinId { get; set; }
    public required string Nom_m { get; set; }
    public required string Prenom_m { get; set; }
    public DateTime Date_naissance_m { get; set; }
    public required string Login_m { get; set; }
    public required string Password_m { get; set; }
    public required string Role { get; set; }

    public List<Ordonnance> Ordonnances { get; set; } = new();
}
