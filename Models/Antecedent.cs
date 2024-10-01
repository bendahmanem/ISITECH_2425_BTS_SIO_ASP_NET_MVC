using System;

namespace ASPBookProject.Models;

public class Antecedent
{

    public int AntecedentId { get; set; }
    public required string Libelle_a { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();
}
