using System;

namespace ASPBookProject.Models;

public class Medicament
{
    public int MedicamentId { get; set; }
    public required string Libelle_med { get; set; }
    public required string Contr_indication { get; set; }

    public List<Allergie> Allergies { get; set; } = new();
    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
