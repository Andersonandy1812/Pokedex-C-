using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class Creating_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPokemonId",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOfPokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPokemons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TypeOfPokemonId",
                table: "Pokemons",
                column: "TypeOfPokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_TypeOfPokemons_TypeOfPokemonId",
                table: "Pokemons",
                column: "TypeOfPokemonId",
                principalTable: "TypeOfPokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_TypeOfPokemons_TypeOfPokemonId",
                table: "Pokemons");

            migrationBuilder.DropTable(
                name: "TypeOfPokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_TypeOfPokemonId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "TypeOfPokemonId",
                table: "Pokemons");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
