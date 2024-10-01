using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPBookProject.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle_al = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergieId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Antecedents",
                columns: table => new
                {
                    AntecedentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle_a = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecedents", x => x.AntecedentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsTenured = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    MedecinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom_m = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom_m = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date_naissance_m = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Login_m = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password_m = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.MedecinId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    MedicamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle_med = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contr_indication = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.MedicamentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom_p = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom_p = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sexe_p = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Num_secu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roster",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsVeteran = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GPA = table.Column<double>(type: "double", nullable: false),
                    Major = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roster", x => x.StudentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AllergieMedicament",
                columns: table => new
                {
                    AllergiesAllergieId = table.Column<int>(type: "int", nullable: false),
                    MedicamentsMedicamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergieMedicament", x => new { x.AllergiesAllergieId, x.MedicamentsMedicamentId });
                    table.ForeignKey(
                        name: "FK_AllergieMedicament_Allergies_AllergiesAllergieId",
                        column: x => x.AllergiesAllergieId,
                        principalTable: "Allergies",
                        principalColumn: "AllergieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergieMedicament_Medicaments_MedicamentsMedicamentId",
                        column: x => x.MedicamentsMedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AntecedentMedicament",
                columns: table => new
                {
                    AntecedentsAntecedentId = table.Column<int>(type: "int", nullable: false),
                    MedicamentsMedicamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentMedicament", x => new { x.AntecedentsAntecedentId, x.MedicamentsMedicamentId });
                    table.ForeignKey(
                        name: "FK_AntecedentMedicament_Antecedents_AntecedentsAntecedentId",
                        column: x => x.AntecedentsAntecedentId,
                        principalTable: "Antecedents",
                        principalColumn: "AntecedentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AntecedentMedicament_Medicaments_MedicamentsMedicamentId",
                        column: x => x.MedicamentsMedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AllergiePatient",
                columns: table => new
                {
                    AllergiesAllergieId = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergiePatient", x => new { x.AllergiesAllergieId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_AllergiePatient_Allergies_AllergiesAllergieId",
                        column: x => x.AllergiesAllergieId,
                        principalTable: "Allergies",
                        principalColumn: "AllergieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergiePatient_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AntecedentPatient",
                columns: table => new
                {
                    AntecedentsAntecedentId = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentPatient", x => new { x.AntecedentsAntecedentId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_AntecedentPatient_Antecedents_AntecedentsAntecedentId",
                        column: x => x.AntecedentsAntecedentId,
                        principalTable: "Antecedents",
                        principalColumn: "AntecedentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AntecedentPatient_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ordonnances",
                columns: table => new
                {
                    OrdonnanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Posologie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duree_traitement = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instructions_specifique = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedecinId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnances", x => x.OrdonnanceId);
                    table.ForeignKey(
                        name: "FK_Ordonnances_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "MedecinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordonnances_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentOrdonnance",
                columns: table => new
                {
                    MedicamentsMedicamentId = table.Column<int>(type: "int", nullable: false),
                    OrdonnancesOrdonnanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentOrdonnance", x => new { x.MedicamentsMedicamentId, x.OrdonnancesOrdonnanceId });
                    table.ForeignKey(
                        name: "FK_MedicamentOrdonnance_Medicaments_MedicamentsMedicamentId",
                        column: x => x.MedicamentsMedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentOrdonnance_Ordonnances_OrdonnancesOrdonnanceId",
                        column: x => x.OrdonnancesOrdonnanceId,
                        principalTable: "Ordonnances",
                        principalColumn: "OrdonnanceId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "EmailAddress", "FirstName", "HiringDate", "IsTenured", "LastName", "Password", "PersonalUrl", "PhoneNumber", "Rank" },
                values: new object[,]
                {
                    { 1, null, "Jane", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Doe", null, null, null, 3 },
                    { 2, null, "John", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Smith", null, null, null, 1 },
                    { 3, null, "Jane", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Smith", null, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Roster",
                columns: new[] { "StudentId", "AdmissionDate", "FirstName", "GPA", "IsVeteran", "LastName", "Major" },
                values: new object[] { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 3.5, false, "Doe", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AllergieMedicament_MedicamentsMedicamentId",
                table: "AllergieMedicament",
                column: "MedicamentsMedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiePatient_PatientsPatientId",
                table: "AllergiePatient",
                column: "PatientsPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentMedicament_MedicamentsMedicamentId",
                table: "AntecedentMedicament",
                column: "MedicamentsMedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentPatient_PatientsPatientId",
                table: "AntecedentPatient",
                column: "PatientsPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentOrdonnance_OrdonnancesOrdonnanceId",
                table: "MedicamentOrdonnance",
                column: "OrdonnancesOrdonnanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnances_MedecinId",
                table: "Ordonnances",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnances_PatientId",
                table: "Ordonnances",
                column: "PatientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergieMedicament");

            migrationBuilder.DropTable(
                name: "AllergiePatient");

            migrationBuilder.DropTable(
                name: "AntecedentMedicament");

            migrationBuilder.DropTable(
                name: "AntecedentPatient");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "MedicamentOrdonnance");

            migrationBuilder.DropTable(
                name: "Roster");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Antecedents");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Ordonnances");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
