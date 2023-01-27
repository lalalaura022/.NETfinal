using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectfinaal2.Migrations
{
    public partial class AddedAnimalMedicament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gramaj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalMedicamente",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    MedicamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalMedicamente", x => new { x.MedicamentId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_AnimalMedicamente_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalMedicamente_Medicamente_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicamente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMedicamente_AnimalId",
                table: "AnimalMedicamente",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalMedicamente");

            migrationBuilder.DropTable(
                name: "Medicamente");
        }
    }
}
