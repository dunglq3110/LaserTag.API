using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaserTag_API.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mac_gun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mac_vest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    current_health = table.Column<int>(type: "int", nullable: true),
                    current_bullet = table.Column<int>(type: "int", nullable: true),
                    balance = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
